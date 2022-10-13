using CommunityToolkit.Mvvm.Input;
using Sispakcf.Models;
using System.Text;
using System.Text.Json;

namespace Sispakcf.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        BindingContext = new ProfilePageViewModel();
    }



    public partial class ProfilePageViewModel : ViewModelBase
    {
        public ProfilePageViewModel()
        {

            var model = Helper.GetProfile();

            if (model == null)
            {
                Shell.Current.DisplayAlert("Info", "Silahkan Logout Dan Masuk Kembali", "OK");
                Shell.Current.Navigation.PopAsync();
            }
            else {
                Model = model;
            }
        }

        private Pasien pasien;

        public Pasien Model
        {
            get { return pasien; }
            set { SetProperty(ref pasien , value); }
        }





        [RelayCommand]
        Task Back()
        {
            Shell.Current.Navigation.PopAsync();
            return Task.CompletedTask;
        }


        [RelayCommand]
        async Task Save()
        {
            try
            {
                var result = await Pasien.PuAsync(Model.Id, Model);
                await Application.Current.MainPage.DisplayAlert("Success", "Tersimpan !", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}