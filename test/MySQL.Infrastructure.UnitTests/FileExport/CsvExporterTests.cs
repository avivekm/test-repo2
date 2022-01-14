using MySQL.Application.Features.Events.Queries.GetEventsExport;
using MySQL.Infrastructure.FileExport;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace MySQL.Infrastructure.UnitTests.FileExport
{
    public class CsvExporterTests
    {
        [Fact]
        public void ExportEventsToCsv()
        {
            var exporter = new CsvExporter();

            var result = exporter.ExportEventsToCsv(new List<EventExportDto>());

            result.ShouldNotBeNull();
            result.ShouldBeOfType<byte[]>();
        }
    }
}
