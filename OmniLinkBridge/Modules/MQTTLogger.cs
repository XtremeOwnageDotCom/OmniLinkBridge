using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Diagnostics;
using Serilog;

namespace OmniLinkBridge.Modules
{
    public class MQTTLogger : IMqttNetLogger, IMqttNetScopedLogger
    {
        private static readonly ILogger log = Log.Logger.ForContext(typeof(MQTTLogger));

        public IMqttNetScopedLogger CreateScopedLogger(string source)
        {
            return this;
        }

        public void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception)
        {
            Publish(logLevel, message, parameters, exception);
        }

        public void Publish(MqttNetLogLevel logLevel, string message, object[] parameters, Exception exception)
        {
            switch (logLevel)
            {
                case MqttNetLogLevel.Verbose:
                    log.Verbose(message);
                    break;
                case MqttNetLogLevel.Info:
                    log.Information(message);
                    break;
                case MqttNetLogLevel.Warning:
                    log.Warning(message);
                    break;
                case MqttNetLogLevel.Error:
                    log.Error(exception, message);
                    break;
            }
        }
    }
}
