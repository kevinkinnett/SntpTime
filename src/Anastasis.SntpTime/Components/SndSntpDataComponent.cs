using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class SndSntpDataComponent : PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            payload.TimeSocket.Send(payload.SntpData, payload.SntpData.Length);
            var payloadIpEndPoint = payload.IPEndPoint;
            payload.SntpData = payload.TimeSocket.Receive(ref payloadIpEndPoint);

            return payload;
        }
    }
}