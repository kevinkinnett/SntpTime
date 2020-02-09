using System;
using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class BuildUriComponent: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            if(!string.IsNullOrWhiteSpace(payload.TimeServerHost))
                payload.TimeServerUri = (new UriBuilder(payload.TimeServerHost) { Port = 123 }).Uri;
            return payload;
        }
    }
}