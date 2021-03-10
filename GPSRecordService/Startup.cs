using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GPSRecordService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MediatR;
using RabbitMQ.Client;
using GPSRecordService.Sender;
using GPSRecordService.Repository;
using GPSRecordService.Service.Command;

using EventBus;
using EventBus.Abstractions;
using EventBusServiceBus;
using EventBusRabbitMQ;
//using Microsoft.Azure.ServiceBus;


namespace GPSRecordService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GPSRecordService", Version = "v1" });
            });
            services.AddDbContext<GPSRecordContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

           
                services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
                {
                    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                    var factory = new ConnectionFactory()
                    {
                        HostName = Configuration["RabbitMq"],
                        DispatchConsumersAsync = true
                    };
                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:Port"]))
                    {
                        factory.Port = Convert.ToInt32(Configuration["RabbitMq:Port"]);
                    }

                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:Hostname"]))
                    {
                        factory.UserName = Configuration["RabbitMq:Hostname"];
                    }

                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:UserName"]))
                    {
                        factory.Password = Configuration["RabbitMq:UserName"];
                    }

                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:guest"]))
                    {
                        factory.Password = Configuration["RabbitMq:guest"];
                    }


                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["RabbitMq:EventBusRetryCount"]);
                    }

                    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                });
            

            //RegisterEventBus(services);

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IGPSRecordRepository, GPSRecordRepository>();

            services.AddTransient<IRequestHandler<CreateGPSRecordCommand, GPSRecord>, CreateGPSRecordCommandHandler>();


            services.AddSingleton<IGPSRecordCreateSender, GPSRecordCreateSender>();

            

            services.AddOptions();

            var container = new ContainerBuilder();
            container.Populate(services);

            new AutofacServiceProvider(container.Build());

        }

        private void RegisterEventBus(IServiceCollection services)
        {
            var subscriptionClientName = Configuration["SubscriptionClientName"];

            
                services.AddSingleton<IEventBus, EventBusRabbitMQ.EventBusRabbitMQ>(sp =>
                {
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ.EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["RabbitMq:EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["RabbitMq:EventBusRetryCount"]);
                    }

                    return new EventBusRabbitMQ.EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                });
            

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GPSRecordService v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        }

    }
}
