using MySQL.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace MySQL.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
