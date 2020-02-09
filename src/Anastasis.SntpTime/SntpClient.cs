using System;
using System.Net;
using System.Net.Sockets;
using Anastasis.SntpTime.Components;
using Anastasis.SntpTime.DependencyInjection;
using Anastasis.SntpTime.Exceptions;
using LightInject;
using PipelineFramework.Abstractions;
using PipelineFramework.Builder;

namespace Anastasis.SntpTime
{
    public class SntpClient
    {
        private static IPipeline<PipelinePayload> GetPipeline()
        {
            var container = new ServiceContainer();
            container.RegisterFrom<CompositionRoot>();

            var pipeline = container.GetInstance<IPipeline<PipelinePayload>>();
            return pipeline;
        }

        /// <summary>
        /// Returns the current Date/Time from the specified time server in UTC
        /// </summary>
        /// <param name="timeServerHost">The hostname of the time server you want to talk to, using a default port of 123</param>
        /// <returns></returns>
        public static DateTime GetTime(string timeServerHost)
        {
            try
            {
                var pipeline = GetPipeline();
                var payload = new PipelinePayload()
                {
                    TimeServerHost = timeServerHost
                };
                pipeline.Execute(payload);

                return payload.TimeInUtc;
            }
            catch (SocketException e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns the current Date/Time from the specified time server in UTC
        /// </summary>
        /// <param name="uri">The URI of the time server you want to talk to</param>
        /// <returns></returns>
        public static DateTime GetTime(Uri uri)
        {
            try
            {
                var pipeline = GetPipeline();
                var payload = new PipelinePayload()
                {
                    TimeServerUri = uri
                };
                pipeline.Execute(payload);

                return payload.TimeInUtc;
            }
            catch (SocketException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}