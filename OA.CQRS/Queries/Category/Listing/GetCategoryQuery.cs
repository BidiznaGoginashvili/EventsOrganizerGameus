using MediatR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OA.CQRS.Queries.Category.Listing
{
    public class GetCategoryQuery : IRequest<List<SelectListItem>>
    {
        public int Id { get; set; }
    }
}
