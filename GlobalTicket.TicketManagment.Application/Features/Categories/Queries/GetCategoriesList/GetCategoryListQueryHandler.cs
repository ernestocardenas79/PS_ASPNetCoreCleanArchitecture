using AutoMapper;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;
using GlobalTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{
	private readonly IMapper _mapper;
	private readonly IAsyncRepository<Category> _categoryRepository;

	public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> _categoryRepository)
	{
		_mapper = mapper;
		this._categoryRepository = _categoryRepository;
	}

	public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
	{
		var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
		return _mapper.Map<List<CategoryListVm>>(allCategories);
	}
}