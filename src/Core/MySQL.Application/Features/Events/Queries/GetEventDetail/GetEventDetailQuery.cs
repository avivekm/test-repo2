using MySQL.Application.Responses;
using MediatR;
using System;

namespace MySQL.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
