using BaseApp.Infrastructure.Constants;
using BaseApp.Infrastructure.Enums;
using BaseApp.Infrastructure.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Headers;

namespace BaseApp.Service.Service
{
    public class WebServiceBase<T> where T : class
    {
        public static async Task<T> RequestAsync(string service, RequestType requestType = RequestType.Get, object SendObject = null, int triesNumber = 0)
        {
            T tReturn = null;
            var url = $"{BaseAppConstants.BaseURL}{service}";

            for (int i = 0; i <= triesNumber; i++)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                        var content = JsonHelper.ObjectToJson(T);

                        switch (requestType)
                        {
                            case RequestType.Get:
                                response = await client.GetAsync(url);
                                break;
                            case RequestType.Post:
                                response = await client.PostAsync(url, httpContent);
                                break;
                            case RequestType.Put:
                                response = await client.PutAsync(url, httpContent);
                                break;
                            case RequestType.Delete:
                                response = await client.DeleteAsync(url);
                                break;
                            default:
                                break;
                        }

                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();

                            var objetoRetorno = JsonHelper<T>.JsonToObject(responseString);


                            tReturn = objetoRetorno;

                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                            {
                                if (i == triesNumber)
                                    throw new Exception("Tempo limite atingido");
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                                throw new Exception("Serviço não encontrado");
                            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                            {
                                if (i == triesNumber)
                                    throw new Exception("Serviço indisponível no momento");
                            }
                            else
                                throw new Exception("Falha no acesso!");
                        }
                    }

                }
                catch (JsonException x)
                {
                    throw x;
                }
                catch (Exception x)
                {
                    throw x;
                }
            }

            return tReturn;

        }
    }
}
