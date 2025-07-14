using Dapper;
using System.Data;

namespace eshift_management.Data.TypeHandlers
{
    /// <summary>
    /// Handles conversion between the JobStatus enum and the string values stored in the database.
    /// </summary>
    public class JobStatusTypeHandler : SqlMapper.TypeHandler<JobStatus>
    {
        public override void SetValue(IDbDataParameter parameter, JobStatus value)
        {
            parameter.Value = value.ToString(); // Store as string (e.g., "Pending")
            parameter.DbType = DbType.String;
        }

        public override JobStatus Parse(object value)
        {
            return Enum.TryParse(value.ToString(), out JobStatus status)
                ? status
                : throw new DataException($"Cannot convert '{value}' to JobStatus enum.");
        }
    }
}
