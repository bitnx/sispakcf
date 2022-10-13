using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sispakcf.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private async void logoutClick(object sender, EventArgs e)
        {
            //await Account.SetProfile(null);
            //await Account.SetUser(null);

            Preferences.Set("pasien", null);
            Preferences.Set("account", null);
            Preferences.Set("token", null);
            Preferences.Set("userName", null);
            Helper.SetPage(new LoginPage());
        }
    }
}