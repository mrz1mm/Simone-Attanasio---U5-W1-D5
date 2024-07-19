using Epimunicipal.Models;
using Microsoft.Data.SqlClient;

namespace Epimunicipal.Service
{
    public class ViolationTypeSvc
    {
        private readonly IConfiguration _config;

        public ViolationTypeSvc(IConfiguration config)
        {
            _config = config;
        }

        public ViolationType GetViolationType(int id)
        {
            try
            {
                ViolationType violationType = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID = "SELECT * FROM ViolationTypes WHERE ViolationTypeId = @ViolationTypeId";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID, conn))
                    {
                        cmd.Parameters.AddWithValue("@ViolationTypeId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                {
                                    violationType = new ViolationType();
                                    violationType.ViolationTypeId = reader.GetInt32(0);
                                    violationType.Description = reader.GetString(1);
                                };
                            }
                        }
                    }

                }
                return violationType;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero del Tipo di Violazione", ex);
            }
        }


        public List<ViolationType> GetViolationTypes()
        {
            try
            {
                List<ViolationType> violationTypes = new List<ViolationType>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL = "SELECT * FROM ViolationTypes";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ViolationType violationType = new ViolationType();
                                violationType.ViolationTypeId = reader.GetInt32(0);
                                violationType.Description = reader.GetString(1);
                                violationTypes.Add(violationType);
                            }
                        }
                    }
                }
                return violationTypes;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Tipi di Violazione", ex);
            }
        }

    }
}
