using Dapper;
using DataExchange.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataExchange
{
    public class MedicationExchange : IMedicationExchange
    {
        private readonly string connectionString;

        public string stringdeconexion { get; set; }

        public MedicationExchange(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Medication Create(Medication medication)
        {
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    string spName = "CreateMedication";
                    var retorno = cn.ExecuteScalar<int>(spName,
                        new { nome = medication.nome, cantidade = medication.cantidade, dataCreacion = medication.dataCreacion },
                        commandType: CommandType.StoredProcedure
                        );
                    medication.Id = retorno;
                }
                catch
                {
                    throw;
                }

            }

            return medication;

        }

        public List<Medication> GetAllMedications()
        {
            List<Medication> lst = new List<Medication>();
            string spName = "GetAllMedications";
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    lst = cn.Query<Medication>(spName, commandType: CommandType.StoredProcedure).ToList();

                }
                catch
                {
                    throw;
                }
            }
            return lst;
        }

        public void Delete(int medicationID)
        {
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    string spName = "DeleteMedication";
                    cn.Execute(spName,
                        new { @ID = medicationID },
                        commandType: CommandType.StoredProcedure
                        );
                }
                catch
                {
                    throw;
                }

            }


        }
        public Medication GetMedicationByID(int medicationID)
        {
            Medication medication = new Medication();
            using (var cn = new SqlConnection(connectionString))
            {
                try
                {
                    string spName = "GetMedicationByID";
                    medication = cn.Query<Medication>(spName, new { @Id = medicationID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch
                {
                    throw;
                }

            }

            return medication;


        }

    }
}
