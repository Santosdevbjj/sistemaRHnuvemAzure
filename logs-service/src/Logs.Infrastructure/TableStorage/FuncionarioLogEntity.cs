using Azure;
using Azure.Data.Tables;

namespace Logs.Infrastructure.TableStorage;

public class FuncionarioLogEntity : ITableEntity
{
    public string PartitionKey { get; set; } = default!;
    public string RowKey { get; set; } = default!;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public int FuncionarioId { get; set; }
    public string SnapshotJson { get; set; } = default!;
    public string TipoAlteracao { get; set; } = default!;
    public string AlteradoPor { get; set; } = "system";
    public DateTime DataAlteracao { get; set; } = DateTime.UtcNow;
}
