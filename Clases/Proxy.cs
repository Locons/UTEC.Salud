using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;
using UTEC.Salud.Models;

namespace UTEC.Salud.Clases
{
    public class Proxy
    {
        private readonly IConfiguration _configuration;

        public Proxy()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public List<Afiliado> ListarAfiliados ()
        {
            List<Afiliado> respuesta = new List<Afiliado>();

            try
            {
                string url = "https://04x9pa1efe.execute-api.us-east-1.amazonaws.com/Prod/Afiliados/ListarAfiliados";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Content = new StringContent("", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = JsonConvert.DeserializeObject<List<Afiliado>>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new Exception(error.message);
                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cita> ListarCita()
        {
            List<Cita> respuesta = new List<Cita>();

            try
            {
                string url = "https://04x9pa1efe.execute-api.us-east-1.amazonaws.com/Prod/Citas/ListarCitas";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Content = new StringContent("", Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = JsonConvert.DeserializeObject<List<Cita>>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new Exception(error.message);
                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
