using MassTransit;
using MassTransit.Mediator;
using NotificationConsumer.Application.IntegrationEvents;

namespace NotificationConsumer.Presentation.Consumers;

public class VehicleOfflineEventConsumer: IConsumer<VehicleOfflineEvent>
{
         private readonly IMediator _mediator;  
         public VehicleOfflineEventConsumer(IMediator mediator) { _mediator = mediator; }  
         
         public async Task Consume( ConsumeContext<VehicleOfflineEvent> context) 
        {  
            var message = context.Message;  
            var command = new {
                message.vehicleId, 
                message.OccurredAt,
                message.EventId};  
            await _mediator.Send(command);  
        } 
}
