using GlobalTicket.TicketManagment.Domain.Entities;

namespace GlobalTicket.TicketManagment.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
	Task<List<Category>> GetCategoriesWithEvents(bool includeHistory);
}
