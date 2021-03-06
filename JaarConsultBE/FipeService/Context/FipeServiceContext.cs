using Application.Interface;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FipeService.Context
{
    public class AplicationFipeApi : IAplicationFipeApi
    {
        private readonly string _apiPath;
        private IList<Veiculo> _veiculosList;
       
        public AplicationFipeApi(string apiPath)
        {
            _apiPath = apiPath;          

        }

        public async Task<Veiculo> ReturnDataFromFipe(Veiculo veiculo)
        {           
                await ResultDataFromApi(veiculo);
                if (_veiculosList == null) return null;

                var resultByYear = _veiculosList.Where(v => v.AnoModelo == veiculo.AnoModelo).FirstOrDefault();
                return resultByYear;
            
          
        }

        private async Task ResultDataFromApi(Veiculo veiculo)
        {
            using (var httpClient = new HttpClient())
            {
                using (var result = await httpClient.GetAsync(_apiPath + "/" + veiculo.CodigoFipe))
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) return;
                   
                    string apiResponse = await result.Content.ReadAsStringAsync();                   
                    _veiculosList = JsonConvert.DeserializeObject<List<Veiculo>>(apiResponse);                  
                
                }
            }
        }
    }
}
