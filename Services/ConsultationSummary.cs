using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceCareClinicSystem.Models
{
    public class ConsultationSummary
    {
        public int ConsultationId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string AgeSex { get; set; }
        public string VisitType { get; set; }
        public string ChiefComplaint { get; set; }
        public string Vitals { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public string Outcome { get; set; }
        public string HandledBy { get; set; }
        public DateTime VisitDate { get; set; }
    }
}