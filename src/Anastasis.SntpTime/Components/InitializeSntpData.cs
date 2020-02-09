using System;
using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class InitializeSntpData: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            // Set version number to 4 and Mode to 3 (client)
            payload.SntpData[0] = 0x1B;
            // Initialize all other fields with 0
            Array.Clear(payload.SntpData, 1, payload.SntpData.Length - 1);

            return payload;
        }
    }
}