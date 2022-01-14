using AutoMapper;
using MySQL.Application.Contracts.Persistence;
using MySQL.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MySQL.Application.Profiles;
using MySQL.Application.Responses;
using MySQL.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MySQL.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListWithEventsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoriesListWithEventsQueryHandlerTests()
        {
            _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_CategoriesList_WithEvents_IncludeHistory()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery(){ IncludeHistory = true }, CancellationToken.None);
            
            result.ShouldBeOfType<Response<IEnumerable<CategoryEventListVm>>>();
        }

        [Fact]
        public async Task Get_CategoriesList_WithEvents_DoNotIncludeHistory()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListWithEventsQuery() { IncludeHistory = false }, CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<CategoryEventListVm>>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
