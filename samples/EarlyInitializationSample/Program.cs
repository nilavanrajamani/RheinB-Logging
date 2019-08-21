using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Json;

namespace EarlyInitializationSample
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .WriteTo.File(new JsonFormatter(), path: @"c:\temp\logs\serilog_sample.json", shared: true)
                .Enrich.FromLogContext()                
                .WriteTo.Console(
                    // {Properties:j} added:
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} " +
                                    "{Properties:j}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                Log.Information("Getting the motors running...");

                BuildWebHost(args).Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .UseSerilog()
                .Build();
    }
}
