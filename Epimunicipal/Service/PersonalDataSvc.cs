using Epimunicipal.Models;
using Epimunicipal.Models.Dto;
using Microsoft.Data.SqlClient;

namespace Epimunicipal.Service
{
    public class PersonalDataSvc
    {
        private readonly IConfiguration _config;

        public PersonalDataSvc(IConfiguration config)
        {
            _config = config;
        }

        public PersonalData GetPersonalData(int id)
        {
            try
            {
                PersonalData personalData = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID = "SELECT * FROM PersonalDatas WHERE PersonalDataId = @PersonalDataId";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonalDataId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                {
                                    personalData = new PersonalData();
                                    personalData.PersonalDataId = reader.GetInt32(0);
                                    personalData.Surname = reader.GetString(1);
                                    personalData.Name = reader.GetString(2);
                                    personalData.Address = reader.GetString(3);
                                    personalData.City = reader.GetString(4);
                                    personalData.ZipCode = reader.GetString(5);
                                    personalData.TaxIdCode = reader.GetString(6);

                                };
                            }
                        }
                    }

                }
                return personalData;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Dati Personali", ex);
            }
        }

        public List<PersonalData> GetPersonalDatas()
        {
            try
            {
                List<PersonalData> personalDatas = new List<PersonalData>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL = "SELECT * FROM PersonalDatas";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonalData personalData = new PersonalData();
                                personalData.PersonalDataId = reader.GetInt32(0);
                                personalData.Surname = reader.GetString(1);
                                personalData.Name = reader.GetString(2);
                                personalData.Address = reader.GetString(3);
                                personalData.City = reader.GetString(4);
                                personalData.ZipCode = reader.GetString(5);
                                personalData.TaxIdCode = reader.GetString(6);
                                personalDatas.Add(personalData);
                            }
                        }
                    }
                }
                return personalDatas;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei Dati Personali", ex);
            }
        }

        public void AddPersonalData(PersonalDataDto personalDataDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT = "INSERT INTO PersonalDatas (Surname, Name, Address, City, ZipCode, TaxIdCode) VALUES (@Surname, @Name, @Address, @City, @ZipCode, @TaxIdCode)";
                    using (SqlCommand cmd = new SqlCommand(INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue("@Surname", personalDataDto.Surname);
                        cmd.Parameters.AddWithValue("@Name", personalDataDto.Name);
                        cmd.Parameters.AddWithValue("@Address", personalDataDto.Address);
                        cmd.Parameters.AddWithValue("@City", personalDataDto.City);
                        cmd.Parameters.AddWithValue("@ZipCode", personalDataDto.ZipCode);
                        cmd.Parameters.AddWithValue("@TaxIdCode", personalDataDto.TaxIdCode);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento dei Dati Personali", ex);
            }
        }

        public void UpdatePersonalData(PersonalData personalData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string UPDATE = "UPDATE PersonalDatas SET Surname = @Surname, Name = @Name, Address = @Address, City = @City, ZipCode = @ZipCode, TaxIdCode = @TaxIdCode WHERE PersonalDataId = @PersonalDataId";
                    using (SqlCommand cmd = new SqlCommand(UPDATE, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonalDataId", personalData.PersonalDataId);
                        cmd.Parameters.AddWithValue("@Surname", personalData.Surname);
                        cmd.Parameters.AddWithValue("@Name", personalData.Name);
                        cmd.Parameters.AddWithValue("@Address", personalData.Address);
                        cmd.Parameters.AddWithValue("@City", personalData.City);
                        cmd.Parameters.AddWithValue("@ZipCode", personalData.ZipCode);
                        cmd.Parameters.AddWithValue("@TaxIdCode", personalData.TaxIdCode);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'aggiornamento dei Dati Personali", ex);
            }
        }

        public void DeletePersonalData(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string DELETE = "DELETE FROM PersonalDatas WHERE PersonalDataId = @PersonalDataId";
                    using (SqlCommand cmd = new SqlCommand(DELETE, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonalDataId", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'eliminazione dei Dati Personali", ex);
            }
        }
    }
}
