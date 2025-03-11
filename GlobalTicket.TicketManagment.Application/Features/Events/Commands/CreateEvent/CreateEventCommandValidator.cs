using FluentValidation;
using GlobalTicket.TicketManagment.Application.Contracts.Persistence;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
{
	private readonly IEventRepository _eventRepository;

	public CreateEventCommandValidator(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;

		RuleFor(p => p.Name)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull()
			.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

		RuleFor(p => p.Price)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

		RuleFor(p => p.Date)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.GreaterThan(DateTime.Now).WithMessage("{PropertyName} should be a future date.");

		RuleFor(p => p.Artist)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

		RuleFor(p => p.Description)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

		RuleFor(p => p.ImageUrl)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");

		RuleFor(p => p.CategoryId)
			.NotEmpty().WithMessage("{PropertyName} is required.");

		RuleFor(p => p)
			.MustAsync(EventNameAndDateUnique)
			.WithMessage("An event with the same name and date already exists.");
	}

	private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
	{
		return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
	}
}
