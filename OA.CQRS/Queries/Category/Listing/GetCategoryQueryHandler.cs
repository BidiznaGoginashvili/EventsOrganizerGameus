using MediatR;
using System.Linq;
using System.Threading;
using OA.Repo.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OA.CQRS.Queries.Category.Listing
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<SelectListItem>>
    {
        #region Fields

        private readonly IRepository<Domain.Category.Category> _categoryRepository;

        #endregion

        #region Ctor

        public GetCategoryQueryHandler(IRepository<Domain.Category.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Handler

        public async Task<List<SelectListItem>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var selectList = categories.SelectMany(category => new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                }
            }).ToList();

            return selectList;
        }

        #endregion
    }
}
