using GlobalTicket.TicketManagment.Domain.Entities;

namespace GlobalTicket.TicketManagment.Application.Contracts.Persistence;

public interface IEventRepository : IAsyncRepository<Event>
{
	Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
}
