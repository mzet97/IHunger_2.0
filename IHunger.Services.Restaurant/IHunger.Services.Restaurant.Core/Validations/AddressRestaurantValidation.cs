using FluentValidation;
using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Core.Validations
{
    public class AddressRestaurantValidation : AbstractValidator<AddressRestaurant>
    {
        public AddressRestaurantValidation()
        {
            RuleFor(a => a.City)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 80).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.County)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 80).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.District)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 80).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 80).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(1, 80).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .MaximumLength(15).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Latitude)
               .MaximumLength(80).WithMessage("The {PropertyName} need to have {MaxLength} characters");

            RuleFor(a => a.Longitude)
               .MaximumLength(80).WithMessage("The {PropertyName} need to have {MaxLength} characters");
        }
    }
}
