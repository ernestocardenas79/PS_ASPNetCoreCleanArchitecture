using GlobalTicket.TicketManagment.Application.Responses;

namespace GlobalTicket.TicketManagment.Application.Features.Categories.Commands;

public class CreateCategoryCommandResponse: BaseResponse
{
	public CreateCategoryCommandResponse() : base()
	{
		
	}

	public CreateCategoryDto Category { get; set; } = default!;
}
