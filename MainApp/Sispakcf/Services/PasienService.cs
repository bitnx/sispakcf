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
    public class PasienService
    {
        private ICollection<Konsultasi> histories;

        internal async Task<Pasien> GetAsync(int id)
        {
            try
            {
                using var rest = new RestService();
                var response = await rest.GetAsync($"/api/pasiens/{id}");
                var stringData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result  = JsonSerializer.Deserialize<Pasien>(stringData, Helper.JsonOptions);
                    if(result!=null && result.Konsultasi != null)
                    {
                        histories.Clear();
                        foreach (var item in result.Konsultasi)
                        {
                            histories.Add(item);
                        }
                    }
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

        internal async Task<Pasien> PuAsync(int id, Pasien model)
        {
            try
            {
                using var rest = new RestService();
                var response = await rest.PutAsync($"/api/pasiens/{id}",rest.GenerateHttpContent(model) );
                var stringData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<Pasien>(stringData, Helper.JsonOptions);
                    Preferences.Set("pasien", stringData);
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


        internal async Task<Konsultasi> SaveHistory(List<Jawaban> jawabans)
        {
            try
            {
                var pasien = Helper.GetProfile();
                using var rest = new RestService();
                var konsultasi = new Konsultasi { GejalaPasien = jawabans, Tanggal = DateTime.Now };
                var response = await rest.PutAsync($"/api/pasiens/history/{pasien.Id}", rest.GenerateHttpContent(konsultasi));
                var stringData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<Konsultasi>(stringData, Helper.JsonOptions);
                    if (histories == null)
                        histories = new List<Konsultasi>();
                    histories.Add(konsultasi);
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

        internal async Task<IEnumerable<Konsultasi>> GetHistoriesAsync()
        {
            try
            {
                if (histories == null)
                {
                    var pasien = Helper.GetProfile();

                    using var rest = new RestService();
                    var response = await rest.GetAsync($"/api/pasiens/{pasien.Id}");
                    var stringData = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonSerializer.Deserialize<Pasien>(stringData, Helper.JsonOptions);
                        if (result != null && result.Konsultasi != null)
                        {
                            histories = new List<Konsultasi>();
                            foreach (var item in result.Konsultasi)
                            {
                                histories.Add(item);
                            }
                        }
                    }
                    else
                    {
                        throw await Helper.ErrorHandle(response);
                    }
                }
                return histories;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }




    }
}
