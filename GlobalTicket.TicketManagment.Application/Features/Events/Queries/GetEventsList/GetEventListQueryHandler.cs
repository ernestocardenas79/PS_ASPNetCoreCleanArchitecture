using AutoMapper;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;
using GlobalTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventsList;

public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListVm>>
{
	private readonly IMapper _mapper;
	private readonly IAsyncRepository<Event> _eventRepository;

	public GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
	{
		_mapper = mapper;
		_eventRepository = eventRepository;
	}

	public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
	{
		var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);

		return _mapper.Map<List<EventListVm>>(allEvents);
	}
}
