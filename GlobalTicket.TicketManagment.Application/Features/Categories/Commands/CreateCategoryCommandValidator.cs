﻿using FluentValidation;

namespace GlobalTicket.TicketManagment.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(p => p.Name)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull()
			.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
	}
}
