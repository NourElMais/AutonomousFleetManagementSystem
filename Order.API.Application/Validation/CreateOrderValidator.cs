using FluentValidation;
using Order.API.Application.DTOs;

namespace Order.API.Application.Validation;

    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(order => order.TotalPrice).InclusiveBetween(0.0M, Decimal.MaxValue).WithMessage("The price cannot be negative");
        }
    }
