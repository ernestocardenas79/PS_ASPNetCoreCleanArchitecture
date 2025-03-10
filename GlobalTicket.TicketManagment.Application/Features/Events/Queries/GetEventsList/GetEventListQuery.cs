using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventsList;

public class GetEventListQuery:IRequest<List<EventListVm>>
{
}
