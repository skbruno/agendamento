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

        public async Task<UserRespondeTokenDTO?> Login(string email, string senha)
        {
            var dados = new { Email = email, password = senha };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7100/api/auth/login", dados);

            if(response.IsSuccessStatusCode)
            {
                var UserData = await response.Content.ReadFromJsonAsync<UserRespondeTokenDTO>();
                return UserData;
            }

            return null;
        }

        public async Task<bool> CreateAccount(string nome, string email, string senha)
        {
            try
            {
                var dados = new { Nome = nome, Email = email, Password = senha };
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7100/api/auth/register", dados);

                if (response.IsSuccessStatusCode)
                    return true;

                //criar um logger futuramente
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
