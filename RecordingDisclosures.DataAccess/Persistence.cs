using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using RecordingDisclosures.Domain;
using RecordingDisclosures.Interfaces;

namespace RecordingDisclosures.DataAccess
{
    public class Persistence : IPersistence
    {
        private readonly SqlSettings _settings;

        public Persistence(IOptions<SqlSettings> settings)
        {
            _settings = settings.Value;
        }

        public bool InsertCarrierPlan(CarrierPlanItem request)
        {
            try
            {
                var timeout = Convert.ToInt32(_settings.CommandTimeout);
                using (var connection = new SqlConnection(_settings.ConnectionString))
                {
                    connection.Execute("sp_insert_carrier_plan", new
                    {
                        request.CarrierId,
                        request.PlanId,
                        request.RecordingOneUrl,
                        request.RecordingTwoUrl,
                        request.RecordingThreeUrl
                    }, commandType: CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
