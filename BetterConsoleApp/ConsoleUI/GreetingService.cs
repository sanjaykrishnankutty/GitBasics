using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleUI
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;
        public GreetingService(ILogger<GreetingService> log, IConfiguration config)

        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            for (var count = 0; count < _config.GetValue<int>("LoopTimes"); count++)
            {
                _log.LogInformation("Run number {runNumber}", count);
            }
        }
    }
}
