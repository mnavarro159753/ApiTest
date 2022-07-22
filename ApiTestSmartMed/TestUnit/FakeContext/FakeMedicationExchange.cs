using Dapper;
using DataExchange;
using DataExchange.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnit.FakeContext
{
    public class FakeMedicationExchange : IMedicationExchange
    {
        List<Medication> medications = new List<Medication>();
        int Id = 0;

        public Medication Create(Medication medication)
        {
            Id++;
            medication.Id = Id;
            medications.Add(medication);
            return medication;
        }

        public List<Medication> GetAllMedications()
        {
            return medications;
        }

        public void Delete(int medicationID)
        {
            medications.RemoveAll(c => c.Id == medicationID);
        }

        public Medication GetMedicationByID(int medicationID)
        {
            return medications.Where(c => c.Id == medicationID).FirstOrDefault();
        }

    }
}
