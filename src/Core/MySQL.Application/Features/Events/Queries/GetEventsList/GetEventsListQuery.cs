using MySQL.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace MySQL.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
