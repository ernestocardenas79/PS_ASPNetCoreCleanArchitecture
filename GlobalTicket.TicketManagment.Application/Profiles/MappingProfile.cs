using AutoMapper;
using GlobalTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using GlobalTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.TicketManagment.Application.Features.Events.Commands.Delete;
using GlobalTicket.TicketManagment.Application.Features.Events.Commands.UpdateEvent;
using GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetail;
using GlobalTicket.TicketManagment.Application.Features.Events.Queries.GetEventsList;
using GlobalTicket.TicketManagment.Domain.Entities;

namespace GlobalTicket.TicketManagment.Application.Profiles;

public class MappingProfile: Profile
{
	public MappingProfile()
	{
		CreateMap<Event, EventListVm>().ReverseMap();
		CreateMap<Event, EventDetailVm>().ReverseMap();
		CreateMap<Category, CategoryDto>().ReverseMap();

		CreateMap<Category, CategoryListVm>().ReverseMap();
		CreateMap<Category, CategoryEventListVm>().ReverseMap();

		CreateMap<Event, CreateEventCommand>().ReverseMap();
		CreateMap<Event, UpdateEventCommand>().ReverseMap();
		CreateMap<Event, DeleteEventCommand>().ReverseMap();
	}
}
