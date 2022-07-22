using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchange.Interfaces
{
    public interface IMedicationExchange
    {
        public Medication Create(Medication medication);
        public List<Medication> GetAllMedications();
        public void Delete(int medicationID);
        public Medication GetMedicationByID(int medicationID);
    }
}
