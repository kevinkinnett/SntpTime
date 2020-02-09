using System.Net.Sockets;
using System.Threading;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class ConnectToTimeServerComponent: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            var timeSocket = new UdpClient();
            timeSocket.Connect(payload.IPEndPoint);

            payload.TimeSocket = timeSocket;

            return payload;
        }
    }
}