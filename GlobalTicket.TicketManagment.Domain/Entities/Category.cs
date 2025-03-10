using GlobalTicket.TicketManagment.Domain.Common;

namespace GlobalTicket.TicketManagment.Domain.Entities;

public class Category: AuditableEntity
{
	public Guid CategoryId { get; set; }
	public string Name { get; set; } = string.Empty;
	public ICollection<Event>? Events { get; set; }
}
