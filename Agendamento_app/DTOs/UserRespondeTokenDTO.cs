namespace Agendamento_app.DTOs
{
    public class UserRespondeTokenDTO
    {
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
