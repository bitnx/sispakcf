using Sispakcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sispakcf.Services
{
    public class SulusiAndGejalaService
    {
        static List<Gejala> listGejala;

        internal async Task<IEnumerable<Hasil>> Calculate(List<Jawaban> jawabans)
        {
            try
            {
                var pasien = Helper.GetProfile();
                using var rest = new RestService();
                var response = await rest.PostAsync($"/api/pasiens/calculate", rest.GenerateHttpContent(jawabans));
                var stringData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<IEnumerable<Hasil>>(stringData, Helper.JsonOptions);
                    return result;
                }
                else
                {
                    throw await Helper.ErrorHandle(response);
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<IEnumerable<Gejala>> GetGejalaAsync()
        {
            try
            {
                if (listGejala == null)
                {
                    using var rest = new RestService();
                    var response = await rest.GetAsync($"/api/gejala");
                    var stringData = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonSerializer.Deserialize<List<Gejala>>(stringData, Helper.JsonOptions);
                        listGejala = result;
                    }
                    else
                    {
                        throw await Helper.ErrorHandle(response);
                    }
                }

                return listGejala;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<Gejala> GetGejalaAsync(int id)
        {
            try
            {
                using var rest = new RestService();
                var response = await rest.GetAsync($"/api/gejalas/{id}");
                var stringData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result  = JsonSerializer.Deserialize<Gejala>(stringData, Helper.JsonOptions);
                    return result;
                }
                else
                {
                    throw await Helper.ErrorHandle(response);
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

  
    }
}
