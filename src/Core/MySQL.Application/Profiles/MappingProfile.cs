using AutoMapper;
using MySQL.Application.Features.Categories.Commands.CreateCategory;
using MySQL.Application.Features.Categories.Commands.StoredProcedure;
using MySQL.Application.Features.Categories.Queries.GetCategoriesList;
using MySQL.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MySQL.Application.Features.Events.Commands.CreateEvent;
using MySQL.Application.Features.Events.Commands.Transaction;
using MySQL.Application.Features.Events.Commands.UpdateEvent;
using MySQL.Application.Features.Events.Queries.GetEventDetail;
using MySQL.Application.Features.Events.Queries.GetEventsExport;
using MySQL.Application.Features.Events.Queries.GetEventsList;
using MySQL.Application.Features.Orders.GetOrdersForMonth;
using MySQL.Domain.Entities;

namespace MySQL.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
