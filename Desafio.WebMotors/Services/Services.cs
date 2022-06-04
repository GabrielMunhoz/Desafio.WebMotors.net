using Desafio.WebMotors.Models;
using Newtonsoft.Json;

namespace Desafio.WebMotors.Services
{
    public static class Services
    {
        public static string BaseUri = "https://desafioonline.webmotors.com.br/";
        public static async Task<List<Make>> getMakes()
        {
            try
            {
                HttpClient ClientHttp = new HttpClient();

                Uri uriMarcas = new Uri(string.Format("{0}/api/OnlineChallenge/Make", BaseUri));

                var response = await ClientHttp.GetAsync(uriMarcas).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                        if (retorno != null)
                        {
                            List<Make> ListMarcas = JsonConvert.DeserializeObject<List<Make>>(retorno);
                            return ListMarcas;
                        }
                    }
                }
                return null; 
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static async Task<List<CarModel>> getModels(int MakeId)
        {
            try
            {
                HttpClient ClientHttp = new HttpClient();

                Uri uriModels = new Uri(string.Format("{0}/api/OnlineChallenge/Model?MakeID={1}", BaseUri, MakeId));

                var response = await ClientHttp.GetAsync(uriModels).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                        if (retorno != null)
                        {
                            List<CarModel> ListModels = JsonConvert.DeserializeObject<List<CarModel>>(retorno);
                            return ListModels;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static async Task<List<Models.Version>> getVersion(int ModelId)
        {
            try
            {
                HttpClient ClientHttp = new HttpClient();

                Uri uriVersion = new Uri(string.Format("{0}/api/OnlineChallenge/Version?ModelID={1}", BaseUri, ModelId));

                var response = await ClientHttp.GetAsync(uriVersion).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                        if (retorno != null)
                        {
                            List<Models.Version> ListVersions = JsonConvert.DeserializeObject<List<Models.Version>>(retorno);
                            return ListVersions;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        //public static async Task<List<Models.Version>> getVehicles(int page)
        //{
        //    try
        //    {
        //        HttpClient ClientHttp = new HttpClient();

        //        Uri uriVehicles = new Uri(string.Format("{0}/api/OnlineChallenge/vehicles?Page={1}", BaseUri, page));

        //        var response = await ClientHttp.GetAsync(uriVehicles).ConfigureAwait(false);
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
        //            {
        //                var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
        //                if (retorno != null)
        //                {
        //                    List<Models.Version> ListVersions = JsonConvert.DeserializeObject<List<Models.Version>>(retorno);
        //                    return ListVersions;
        //                }
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
    }
}
