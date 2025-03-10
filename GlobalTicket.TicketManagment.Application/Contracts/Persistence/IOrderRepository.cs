using GlobalTicket.TicketManagment.Domain.Entities;

namespace GlobalTicket.TicketManagment.Application.Contracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
}