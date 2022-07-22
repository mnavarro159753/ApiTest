using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTestSmartMed.DTOs
{
    public class MedicationDTO
    {
        public string nome { get; set; }
        public int cantidade { get; set; }
        public DateTime dataCreacion { get; set; }
    }
}
