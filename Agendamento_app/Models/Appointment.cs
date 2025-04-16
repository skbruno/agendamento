using Agendamento_app.Models.Enums;

namespace Agendamento_app.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public AppointmentStatus Status {get; set; }

        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        
        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }

        public double ValueTotal { get; set; }



    }
}
