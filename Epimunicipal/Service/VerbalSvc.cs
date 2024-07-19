using Epimunicipal.Models;
using Epimunicipal.Models.Dto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Epimunicipal.Service
{
    public class VerbalSvc : IVerbalSvc
    {
        private readonly IConfiguration _config;
        public VerbalSvc(IConfiguration config)
        {
            _config = config;
        }

        public Verbal GetVerbal(int id)
        {
            try
            {
                Verbal verbal = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID = "SELECT * FROM Verbals WHERE VerbalId = @VerbalId";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID, conn))
                    {
                        cmd.Parameters.AddWithValue("@VerbalId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                verbal = new Verbal();
                                verbal.VerbalId = reader.GetInt32(0);
                                verbal.PersonalDataId = reader.GetInt32(1);
                                verbal.ViolationTypeId = reader.GetInt32(2);
                                verbal.ViolationDate = reader.GetDateTime(3);
                                verbal.ViolationAddress = reader.GetString(4);
                                verbal.AgentName = reader.GetString(5);
                                verbal.VerbalDate = reader.GetDateTime(6);
                                verbal.Amount = reader.GetDecimal(7);
                                verbal.PointDeduction = reader.GetInt32(8);
                            }
                        }
                    }
                }
                return verbal;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero del Verbale", ex);
            }
        }

        public List<Verbal> GetVerbals()
        {
            try
            {
                List<Verbal> verbals = new List<Verbal>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL = "SELECT * FROM Verbals";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Verbal verbal = new Verbal();
                                verbal.VerbalId = reader.GetInt32(0);
                                verbal.PersonalDataId = reader.GetInt32(1);
                                verbal.ViolationTypeId = reader.GetInt32(2);
                                verbal.ViolationDate = reader.GetDateTime(3);
                                verbal.ViolationAddress = reader.GetString(4);
                                verbal.AgentName = reader.GetString(5);
                                verbal.VerbalDate = reader.GetDateTime(6);
                                verbal.Amount = reader.GetDecimal(7);
                                verbal.PointDeduction = reader.GetInt32(8);
                                verbals.Add(verbal);
                            }
                        }
                    }
                }
                return verbals;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Verbali", ex);
            }
        }

        public List<VerbalDetailsDto> GetVerbalsDetails()
        {
            try
            {
                List<VerbalDetailsDto> result = new List<VerbalDetailsDto>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetVerbalsDetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbalDetailsDto verbal = new VerbalDetailsDto
                                {
                                    TransgressorFullName = reader.GetString(reader.GetOrdinal("TransgressorFullName")),
                                    ViolationTypeDescription = reader.GetString(reader.GetOrdinal("ViolationTypeDescription")),
                                    ViolationDate = reader.GetDateTime(reader.GetOrdinal("ViolationDate")),
                                    ViolationAddress = reader.GetString(reader.GetOrdinal("ViolationAddress")),
                                    AgentName = reader.GetString(reader.GetOrdinal("AgentName")),
                                    VerbalDate = reader.GetDateTime(reader.GetOrdinal("VerbalDate")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    PointDeduction = reader.GetInt32(reader.GetOrdinal("PointDeduction"))
                                };
                                result.Add(verbal);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei verbali con dettagli", ex);
            }
        }


        public List<TransgressorVerbalDto> GetVerbalsByTrasgressor()
        {
            try
            {
                List<TransgressorVerbalDto> verbals = new List<TransgressorVerbalDto>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetTransgressorVerbals", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TransgressorVerbalDto trasgressorVerbal = new TransgressorVerbalDto();
                                trasgressorVerbal.FullName = reader.GetString(0);
                                trasgressorVerbal.TotalVerbals = reader.GetInt32(1);
                                verbals.Add(trasgressorVerbal);
                            }
                        }
                    }
                }
                return verbals;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Verbali", ex);
            }
        }

        public List<TransgressorPointsDeductedDto> GetTransgressorPointsDeducted()
        {
            try
            {
                List<TransgressorPointsDeductedDto> result = new List<TransgressorPointsDeductedDto>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetTransgressorTotalPointsDeducted", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TransgressorPointsDeductedDto transgressorPointsDeducted = new TransgressorPointsDeductedDto();
                                transgressorPointsDeducted.FullName = reader.GetString(0);
                                transgressorPointsDeducted.TotalPointsDeducted = reader.GetInt32(1);
                                result.Add(transgressorPointsDeducted);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Punti Decurtati", ex);
            }
        }

        public List<VerbalsPointsDeductionOverTenDto> GetVerbalsPointsDeductedOverTen()
        {
            try
            {
                List<VerbalsPointsDeductionOverTenDto> result = new List<VerbalsPointsDeductionOverTenDto>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetVerbalsPointsDeductionOverTen", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbalsPointsDeductionOverTenDto verbalsPointsDeductionOverTen = new VerbalsPointsDeductionOverTenDto();
                                verbalsPointsDeductionOverTen.FullName = reader.GetString(0);
                                verbalsPointsDeductionOverTen.ViolationDate = reader.GetDateTime(1);
                                verbalsPointsDeductionOverTen.PointDeduction = reader.GetInt32(2);
                                verbalsPointsDeductionOverTen.Amount = reader.GetDecimal(3);
                                result.Add(verbalsPointsDeductionOverTen);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Verbali con Punti Decurtati maggiori di 10", ex);
            }
        }

        public List<VerbalDetailsDto> GetVerbalsDetailsAmourOver400()
        {
            try
            {
                List<VerbalDetailsDto> result = new List<VerbalDetailsDto>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetVerbalsDetailsAmountOver400", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbalDetailsDto verbal = new VerbalDetailsDto
                                {
                                    TransgressorFullName = reader.GetString(reader.GetOrdinal("TransgressorFullName")),
                                    ViolationTypeDescription = reader.GetString(reader.GetOrdinal("ViolationTypeDescription")),
                                    ViolationDate = reader.GetDateTime(reader.GetOrdinal("ViolationDate")),
                                    ViolationAddress = reader.GetString(reader.GetOrdinal("ViolationAddress")),
                                    AgentName = reader.GetString(reader.GetOrdinal("AgentName")),
                                    VerbalDate = reader.GetDateTime(reader.GetOrdinal("VerbalDate")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    PointDeduction = reader.GetInt32(reader.GetOrdinal("PointDeduction"))
                                };
                                result.Add(verbal);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei verbali con dettagli", ex);
            }
        }


        public void AddVerbal(VerbalDto verbalDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT = "INSERT INTO Verbals (PersonalDataId, ViolationTypeId, ViolationDate, ViolationAddress, AgentName, VerbalDate, Amount, PointDeduction) VALUES (@PersonalDataId, @ViolationTypeId, @ViolationDate, @ViolationAddress, @AgentName, @VerbalDate, @Amount, @PointDeduction)";
                    using (SqlCommand cmd = new SqlCommand(INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonalDataId", verbalDto.PersonalDataId);
                        cmd.Parameters.AddWithValue("@ViolationTypeId", verbalDto.ViolationTypeId);
                        cmd.Parameters.AddWithValue("@ViolationDate", verbalDto.ViolationDate);
                        cmd.Parameters.AddWithValue("@ViolationAddress", verbalDto.ViolationAddress);
                        cmd.Parameters.AddWithValue("@AgentName", verbalDto.AgentName);
                        cmd.Parameters.AddWithValue("@VerbalDate", verbalDto.VerbalDate);
                        cmd.Parameters.AddWithValue("@Amount", verbalDto.Amount);
                        cmd.Parameters.AddWithValue("@PointDeduction", verbalDto.PointDeduction);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento del Verbale", ex);
            }
        }


    }
}
