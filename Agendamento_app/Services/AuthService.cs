using Agendamento_app.DTOs;

namespace Agendamento_app.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public AuthService()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7100");
        }

        public async Task<UserRespondeDTO?> Login(string email, string senha)
        {
            var dados = new { Email = email, password = senha };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7100/api/Usuario/api/auth/login", dados);


            if(response.IsSuccessStatusCode)
            {
                var UserData = await response.Content.ReadFromJsonAsync<UserRespondeDTO>();
                return UserData;
            }

            return null;
        }
    }
}
