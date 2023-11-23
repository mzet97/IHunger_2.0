using FluentValidation;
using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Core.Validations
{
    public class CategoryRestaurantValidation : AbstractValidator<CategoryRestaurant>
    {
        public CategoryRestaurantValidation()
        {
            RuleFor(c => c.Name)
             .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
             .Length(3, 50).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(3, 200).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");
        }
    }
}
