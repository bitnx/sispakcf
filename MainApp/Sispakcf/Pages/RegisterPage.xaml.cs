using CommunityToolkit.Mvvm.Input;
using Sispakcf.Models;
using System.Text;

namespace Sispakcf.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterPageViewModel();
    }


    public partial class RegisterPageViewModel : ViewModelBase
    {
        public Pasien Model { get; set; } = new Pasien();

        public RegisterPageViewModel()
        {
            
            Model.PropertyChanged += (_, __) => {
                RegisterCommand = new RelayCommand(async () => await RegisterAction(), RegisterValidate);
            };
        }

        private async Task RegisterAction()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                if (IsValid())
                {
                    Pasien model = await Account.RegisterAsync(Model);
                    if (model != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Success", "Data Berhasil Disimpan !", "OK");
                        Application.Current.MainPage = new LoginPage();
                    }
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            var valid = true;
            if (!IsValidEmail)
            {
                valid = false;
                sb.Append("Email Tidak Valid !; ");
            }

            if (string.IsNullOrEmpty(Model.Nama) || string.IsNullOrEmpty(Model.Pekerjaan)
                || string.IsNullOrEmpty(Model.Alamat)
                || string.IsNullOrEmpty(Model.Email))
            {
                valid = false;
                sb.Append("Lengkapi Data !, Tidak Boleh Kosong ; ");
            }
            ErrorMessage = sb.ToString();
            IsVisibleError = !valid;

            return valid;
        }

        private bool RegisterValidate()
        {


            return true;

        }




        private RelayCommand registerCommand;


        public RelayCommand RegisterCommand
        {
            get { return registerCommand; }
            set { SetProperty(ref registerCommand, value); }
        }



        


    }
}