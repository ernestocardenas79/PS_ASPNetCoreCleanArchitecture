using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
{
}
