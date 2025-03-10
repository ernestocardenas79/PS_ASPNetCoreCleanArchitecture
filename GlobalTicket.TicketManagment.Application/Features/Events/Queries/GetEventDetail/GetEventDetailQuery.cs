using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery: IRequest<EventDetailVm>
{
	public Guid Id { get; set; }
}
