﻿using AutoMapper;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;
using GlobalTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
	private readonly IAsyncRepository<Event> _eventRepository;
	private readonly IMapper _mapper;
	private readonly IAsyncRepository<Category> _categoryRepository;

	public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper, IAsyncRepository<Category> categoryRepository)
	{
		_eventRepository = eventRepository;
		_mapper = mapper;
		_categoryRepository = categoryRepository;
	}

	public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
	{
		var @event= await _eventRepository.GetByIdAsync(request.Id);
		var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

		var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

		eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

		return eventDetailDto;
	}
}