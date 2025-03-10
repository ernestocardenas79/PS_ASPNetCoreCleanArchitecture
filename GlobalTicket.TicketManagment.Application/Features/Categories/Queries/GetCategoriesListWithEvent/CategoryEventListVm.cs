using AutoMapper;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithEvent;

public class CategoryEventListVm
{
	public Guid CategoryId { get; set; }
	public string Name { get; set; }= string.Empty;	
	public ICollection<CategoryEventDto>? Events { get; set; }
}

public class CategoryEventDto
{
	public Guid EventId { get; set; }
	public string Name { get; set; } = string.Empty;
	public int Price { get; set; }
	public string Artist { get; set; } = string.Empty;
	public DateTime Date { get; set; }
	public Guid CategoryId { get; set; }
}


public class  GetCategoriesListWithEventsQuery: IRequest<List<CategoryEventListVm>>
{
	public bool IncludeHistory { get; set; }
}

public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	public GetCategoriesListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}
	public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
	{
		var categories = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
		return _mapper.Map<List<CategoryEventListVm>>(categories);
	}
}