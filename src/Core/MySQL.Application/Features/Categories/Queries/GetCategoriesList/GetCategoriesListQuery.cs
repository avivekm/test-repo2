using MySQL.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace MySQL.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
