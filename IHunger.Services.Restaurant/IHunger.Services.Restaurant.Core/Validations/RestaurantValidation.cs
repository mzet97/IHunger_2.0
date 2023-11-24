using FluentValidation;
using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Core.Validations
{
    public class RestaurantValidation : AbstractValidator<Restaurant>
    {
        public RestaurantValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 50).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 200).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 10000).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");
        }
    }
}
