namespace Agendamento_app.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Appointment> AppointmentsReceived { get; set; } = new List<Appointment>();

        public User()
        {
        }

        public User(int id, string? name, string? email, string? password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public void AddServices(Service sr)
        {
            Services.Add(sr);
        }

        public void RemoveServices(Service sr)
        {
            Services.Remove(sr);
        }

        public void AddAppointments(Appointment Ap)
        {
            AppointmentsReceived.Add(Ap);
        }

        public void RemoveAppointments(Appointment Ap)
        {
            AppointmentsReceived.Remove(Ap);
        }

        public int TotalWorkMonth(DateTime initial, DateTime final)
        {
            return AppointmentsReceived.Where(Ap => Ap.DataHora >= initial && Ap.DataHora <= final).Count();
        }

        public int TotalValueWorkMonth(DateTime initial, DateTime final)
        {
            return (int)AppointmentsReceived.Where(Ap => Ap.DataHora >= initial && Ap.DataHora <= final).Sum(ap => ap.ValueTotal);
        }
    }
}
