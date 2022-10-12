using Microsoft.Maui.Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sispakcf
{
    internal class Helper
    {
        //public static string Url { get; internal set; } = "http://192.168.1.15/";
        public static string Url { get; internal set; } = "https://kontrasepsikb.ocphapp.tech/";
        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        internal static async Task SetPage(Page loginPage)
        {
            await Task.Delay(2000);
            var app = (App)Application.Current;
            app.MainPage = loginPage;
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        internal static async Task<Exception> ErrorHandle(HttpResponseMessage response)
        {

            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _ = LoadLogin();
                    throw new SystemException("Maaf anda tidak memiliki akses !");
                }

                var stringData = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(stringData))
                {
                    throw new SystemException(response.StatusCode.ToString());
                }

                var errorMessage = JsonSerializer.Deserialize<ErrorMessage>(stringData, Helper.JsonOptions);
                throw new SystemException($"{errorMessage.Status} - {errorMessage.Title} - {errorMessage?.Detail}");
            }
            catch (Exception)
            {
                throw new SystemException(response.StatusCode.ToString());
            }
        }

        private static async Task LoadLogin()
        {
            await Task.Delay(5000);
         await  Shell.Current.Navigation.PushAsync(new LoginPage());
        }

     
    }
}