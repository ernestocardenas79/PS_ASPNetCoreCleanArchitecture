using GlobalTicket.TicketManagment.Domain.Entities;

namespace GlobalTicket.TicketManagment.Application.Contracts.Persistence;

public interface IEventRepository : IAsyncRepository<Event>
{
}
