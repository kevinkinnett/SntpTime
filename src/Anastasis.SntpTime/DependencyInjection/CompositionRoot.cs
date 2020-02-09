using Anastasis.SntpTime.Components;
using LightInject;
using PipelineFramework.Abstractions;
using PipelineFramework.Builder;
using PipelineFramework.LightInject;

namespace Anastasis.SntpTime.DependencyInjection
{
    public class CompositionRoot : PipelineCompositionRootBase
    {
        public override void Compose(IServiceRegistry registry)
        {
            base.Compose(registry);

            registry
                .Register<IPipelineComponent<PipelinePayload>, BuildUriComponent>
                    (typeof(BuildUriComponent).Name)
                .Register<IPipelineComponent<PipelinePayload>, CheckResponseValidityComponent>(
                    typeof(CheckResponseValidityComponent).Name)
                .Register<IPipelineComponent<PipelinePayload>, ConnectToTimeServerComponent>(
                    typeof(ConnectToTimeServerComponent).Name)
                .Register<IPipelineComponent<PipelinePayload>, InitializeSntpData>(
                    typeof(InitializeSntpData).Name)
                .Register<IPipelineComponent<PipelinePayload>, ResolveServerAddressComponent>(
                    typeof(ResolveServerAddressComponent).Name)
                .Register<IPipelineComponent<PipelinePayload>, ComputeMillisecondsFromBytes>(
                    typeof(ComputeMillisecondsFromBytes).Name)
                .Register<IPipelineComponent<PipelinePayload>, ComputeDate>(
                    typeof(ComputeDate).Name).Register<IPipelineComponent<PipelinePayload>, SndSntpDataComponent>(
                    typeof(SndSntpDataComponent).Name);

            registry.Register(
                factory => PipelineBuilder<PipelinePayload>
                    .NonAsync()
                    .WithComponent<BuildUriComponent>()
                    .WithComponent<ResolveServerAddressComponent>()
                    .WithComponent<ConnectToTimeServerComponent>()
                    .WithComponent<InitializeSntpData>()
                    .WithComponent<SndSntpDataComponent>()
                    .WithComponent<CheckResponseValidityComponent>()
                    .WithComponent<ComputeMillisecondsFromBytes>()
                    .WithComponent<ComputeDate>()
                    .WithComponentResolver(factory.GetInstance<IPipelineComponentResolver>())
                    .WithNoSettings()
                    .Build());
        }
    }
}