using Sispakcf.Pages;
using Sispakcf.Services;

namespace Sispakcf
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<AccountService>();
            DependencyService.Register<PasienService>();
            DependencyService.Register<SulusiAndGejalaService>();
            var loginUser = Preferences.Get("userName", null);

            if (string.IsNullOrEmpty(loginUser))
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new AppShell();
            }

        }
    }
}