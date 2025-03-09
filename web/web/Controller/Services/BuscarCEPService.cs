using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;



namespace web
{

    public class BuscarCEPService
    {
        private readonly HttpClient _httpClient;

        public BuscarCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponse> GetEnderecoPorCepAsync(string Cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{Cep}/json/");
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Log da resposta bruta
                Console.WriteLine($"Resposta JSON: {jsonResponse}");

                if (response.IsSuccessStatusCode)
                {
                    var endereco = JsonSerializer.Deserialize<ViaCepResponse>(jsonResponse);
                    return endereco;
                }
                else
                {
                    // Log do erro HTTP
                    Console.WriteLine($"Erro HTTP: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log de qualquer exceção capturada
                Console.WriteLine($"Exceção: {ex.Message}");
            }

            return null;
        }

    }
}
