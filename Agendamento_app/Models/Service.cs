namespace Agendamento_app.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public TimeSpan Duracao { get; set; }
        public string? Local { get; set; }

        public ICollection<User> User_ { get; set; } = new List<User>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Service()
        {
        }

        public Service(int id, string nome, string descricao, decimal preco, TimeSpan duracao, string local)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Duracao = duracao;
            Local = local;
        }

        public void AddUser(User user)
        {
            User_.Add(user);
        }

        public void RemoveUser(User user)
        {
            User_.Remove(user);
        }
    }
}
