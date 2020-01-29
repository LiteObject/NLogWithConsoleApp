namespace TestConsoleApp
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NLog.Extensions.Logging;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                    {
                        builder.SetMinimumLevel(LogLevel.Trace);
                        builder.AddNLog(new NLogProviderOptions
                                            {
                                                CaptureMessageTemplates = true,
                                                CaptureMessageProperties = true
                                            });
                    })
                .BuildServiceProvider();

            ILogger<Program> logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogInformation("Starting application...");
            logger.LogError("Test Error.");
            
            logger.LogInformation("Press any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// The write date time.
        /// </summary>
        private static void WriteDateTime()
        {
            var cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

            Console.WriteLine($"DateTime.Today:  {DateTime.Today}");
            Console.WriteLine($"DateTime.Now:    {DateTime.Now}");
            Console.WriteLine($"DateTime.UtcNow: {DateTime.UtcNow}");
            Console.WriteLine($"TimeZoneInfo.Local.DaylightName: {TimeZoneInfo.Local.DaylightName}");
            Console.WriteLine($"TimeZoneInfo.Local.StandardName: {TimeZoneInfo.Local.StandardName}");
            Console.WriteLine($"var cstZone = TimeZoneInfo.FindSystemTimeZoneById(\"Central Standard Time\"): {cstZone}");
            Console.WriteLine($"cstZone.DaylightName: {cstZone.DaylightName}");
            Console.WriteLine($"cstZone.StandardName: {cstZone.StandardName}");
            Console.WriteLine($"TimeZoneInfo.ConvertTime(DateTime.Now, cstZone):           {TimeZoneInfo.ConvertTime(DateTime.Now, cstZone)}");
            Console.WriteLine($"TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone): {TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone)}");
        }
    }
}
