using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class ComputeMillisecondsFromBytes: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            ulong intpart = 0, fractpart = 0;

            for (var i = 0; i <= 3; i++)
                intpart = 256 * intpart + payload.SntpData[Constants.OffReferenceTimestamp + i];

            for (var i = 4; i <= 7; i++)
                fractpart = 256 * fractpart + payload.SntpData[Constants.OffReferenceTimestamp  + i];

            payload.Millisecond = intpart * 1000 + (fractpart * 1000) / 0x100000000L;

            return payload;
        }
    }
}