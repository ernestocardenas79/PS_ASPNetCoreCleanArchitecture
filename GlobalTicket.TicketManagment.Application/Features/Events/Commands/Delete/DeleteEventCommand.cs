using AutoMapper;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;
using GlobalTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Commands.Delete;

public class DeleteEventCommand: IRequest
{
	public Guid EventId { get; set; }
}

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
	private readonly IMapper _mapper;
	private readonly IAsyncRepository<Event> _eventRepository;

	public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
	{
		_mapper = mapper;
		_eventRepository = eventRepository;
	}

	public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
	{
		var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
		await _eventRepository.DeleteAsync(eventToDelete);
	}
}