using BaseApp.Infrastructure.Constants;
using BaseApp.Infrastructure.Enums;
using BaseApp.Infrastructure.Json;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Service.Core
{
    public static class WebServiceBase<T> where T : class
    {
        public static async Task<RespostaPadrão> RequestAsync(string service, string token, int triesNumber = 0, RequestType requestType = RequestType.Get, T SendObject = null)
        {
            RespostaPadrão resposta = null;
            var url = $"{BaseAppConstants.BaseURL}{service}";
            HttpResponseMessage response = new HttpResponseMessage();

            for (int i = 0; i <= triesNumber; i++)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var content = JsonHelper<T>.ObjectToJson(SendObject);

                        switch (requestType)
                        {
                            case RequestType.Get:
                                response = await client.GetAsync(url);
                                break;
                            case RequestType.Post:
                                response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                                break;
                            case RequestType.Put:
                                response = await client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                                break;
                            case RequestType.Delete:
                                response = await client.DeleteAsync(url);
                                break;
                            default:
                                break;
                        }

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();

                            resposta.Content = JsonHelper<T>.JsonToObject(responseString);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                            {
                                if (i == triesNumber)
                                {
                                    resposta.Message = "Tempo limite atingido";
                                    resposta.IsSuccess = false;
                                }
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resposta.Message = "Serviço não encontrado";
                                resposta.IsSuccess = false;
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                            {
                                if (i == triesNumber)
                                {
                                    resposta.Message = "Serviço indisponível no momento";
                                    resposta.IsSuccess = false;
                                }
                            }
                            else
                            {
                                resposta.Message = "Falha no acesso!";
                                resposta.IsSuccess = false;
                            }
                        }
                    }
                }
                catch (JsonException jsonException)
                {
                    resposta.Message = $"JsonException: {jsonException.Message}";
                    resposta.IsSuccess = false;
                }
                catch (Exception exception)
                {
                    resposta.Message = $"Exception: {exception.Message}";
                    resposta.IsSuccess = false;
                }
            }

            return resposta;
        }
    }
}
