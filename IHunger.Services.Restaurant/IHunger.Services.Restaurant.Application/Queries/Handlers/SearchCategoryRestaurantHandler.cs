using IHunger.Services.Restaurants.Application.Dtos.ViewModels;
using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using LinqKit;
using MediatR;
using System.Linq.Expressions;

namespace IHunger.Services.Restaurants.Application.Queries.Handlers
{
    public class SearchCategoryRestaurantHandler : IRequestHandler<SearchCategoryRestaurant, List<CategoryRestaurantViewModel>>
    {
        private readonly ICategoryRestaurantRepository _categoryRestaurantRepository;

        public SearchCategoryRestaurantHandler(ICategoryRestaurantRepository categoryRestaurantRepository)
        {
            _categoryRestaurantRepository = categoryRestaurantRepository;
        }

        public async Task<List<CategoryRestaurantViewModel>> Handle(SearchCategoryRestaurant request, CancellationToken cancellationToken)
        {
            Expression<Func<CategoryRestaurant, bool>>? filter = null;
            Func<IQueryable<CategoryRestaurant>, IOrderedQueryable<CategoryRestaurant>>? ordeBy = null;

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.Name == request.Name);
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.Description == request.Description);
            }

            if (!string.IsNullOrWhiteSpace(request.Order))
            {
                switch (request.Order)
                {
                    case "Id":
                        ordeBy = x => x.OrderBy(n => n.Id);
                        break;
                    case "Name":
                        ordeBy = x => x.OrderBy(n => n.Name);
                        break;
                    case "Description":
                        ordeBy = x => x.OrderBy(n => n.Description);
                        break;
                    case "CreatedAt":
                        ordeBy = x => x.OrderBy(n => n.CreatedAt);
                        break;
                    case "UpdatedAt":
                        ordeBy = x => x.OrderBy(n => n.UpdatedAt);
                        break;
                    case "DeletedAt":
                        ordeBy = x => x.OrderBy(n => n.DeletedAt);
                        break;
                }
            }

            if (request.Id != Guid.Empty)
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.Id == request.Id);
            }

            if (request.CreatedAt.Year > 1)
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.CreatedAt == request.CreatedAt);
            }

            if (request.UpdatedAt.Year > 1)
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.UpdatedAt == request.UpdatedAt);
            }

            if (request.DeletedAt.HasValue || request.DeletedAt?.Year > 1)
            {
                if (filter == null)
                {
                    filter = PredicateBuilder.New<CategoryRestaurant>(true);
                }

                filter = filter.And(x => x.DeletedAt == request.DeletedAt);
            }

            var list = await _categoryRestaurantRepository
                .Search(
                    filter,
                    ordeBy,
                    request.PageSize,
                    request.PageIndex);

            return list.Select(x => CategoryRestaurantViewModel.FromEntity(x)).ToList();
        }
    }
}
