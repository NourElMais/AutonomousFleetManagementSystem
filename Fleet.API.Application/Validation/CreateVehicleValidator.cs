using System.Data;
using Fleet.API.Application.DTOs;
using FluentValidation;

namespace Fleet.API.Application.Validation;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleDTO>
{

    public CreateVehicleValidator()
    {
        RuleFor(vehicle => vehicle.Model).NotEmpty().WithMessage("Vehicle model cannot be empty");
        RuleFor(vehicle => vehicle.Price).GreaterThan(0).WithMessage("Price cannot be negative");
        RuleFor(vehicle=>vehicle.BatteryLevel).GreaterThan(0).InclusiveBetween(0,100).WithMessage("BatteryLevel cannot be negative or greater than 100");
    }
}
