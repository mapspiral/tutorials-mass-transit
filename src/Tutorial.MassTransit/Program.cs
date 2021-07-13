using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tutorial.MassTransit
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<MessageConsumer>();
                        x.UsingInMemory((context, config) =>
                        {
                            config.ConfigureEndpoints(context);
                        });
                    });

                    services.AddMassTransitHostedService(true);

                    services.AddHostedService<Worker>();
                });
        }
    }
}