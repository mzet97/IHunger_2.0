using FluentValidation;
using IHunger.Services.Restaurants.Core.Entities;

namespace IHunger.Services.Restaurants.Core.Validations
{
    public static class Validator
    {
        public static bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : IEntityBase
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            return false;
        }
    }
}
