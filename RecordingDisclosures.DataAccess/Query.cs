using Microsoft.Extensions.Options;
using RecordingDisclosures.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using RecordingDisclosures.Interfaces;

namespace RecordingDisclosures.DataAccess
{
    public class Query : IQuery
    {
        private readonly SqlSettings _settings;

        public Query(IOptions<SqlSettings> settings)
        {
            _settings = settings.Value;
        }

        public List<CarrierItem> ListCarriers()
        {
            var timeout = Convert.ToInt32(_settings.CommandTimeout);

            using var connection = new SqlConnection(_settings.ConnectionString);
            var result = connection.Query<CarrierItem>("sp_get_carriers",
                commandType: CommandType.StoredProcedure, commandTimeout: timeout);
            return result.ToList();
        }

        public List<PlanItem> ListPlans()
        {
            var timeout = Convert.ToInt32(_settings.CommandTimeout);

            using var connection = new SqlConnection(_settings.ConnectionString);
            var result = connection.Query<PlanItem>("sp_get_plans",
                commandType: CommandType.StoredProcedure, commandTimeout: timeout);
            return result.ToList();
        }
    }
}
