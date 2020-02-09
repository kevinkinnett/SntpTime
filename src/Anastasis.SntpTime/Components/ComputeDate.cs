using System;
using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class ComputeDate: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            var time = new DateTime(1900, 1, 1);
            time += TimeSpan.FromMilliseconds(payload.Millisecond);

            // Specify this as UTC
            payload.TimeInUtc = DateTime.SpecifyKind(time, DateTimeKind.Utc);

            return payload;
        }
    }
}