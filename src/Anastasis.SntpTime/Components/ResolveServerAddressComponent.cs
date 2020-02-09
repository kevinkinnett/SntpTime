using System.Net;
using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class ResolveServerAddressComponent: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            var hostEntry = Dns.GetHostEntry(payload.TimeServerUri.Host);
            payload.IPEndPoint = new IPEndPoint(hostEntry.AddressList[0], payload.TimeServerUri.Port);
            return payload;
        }
    }
}