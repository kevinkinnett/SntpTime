using System.Threading;
using Anastasis.SntpTime.Exceptions;
using PipelineFramework.Abstractions;

namespace Anastasis.SntpTime.Components
{
    public class CheckResponseValidityComponent: PipelineComponentBase<PipelinePayload>
    {
        public override PipelinePayload Execute(PipelinePayload payload, CancellationToken cancellationToken)
        {
            if (!(payload.SntpData.Length >= Constants.SntpDataLength &&
                  Utilities.GetModeFromByteArray(payload.SntpData) == Mode.Server))
                throw new SntpServerException(("Invalid response from " + payload.TimeServerUri.Scheme));

            return payload;
        }
    }
}