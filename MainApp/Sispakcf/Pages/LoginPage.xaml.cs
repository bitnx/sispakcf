using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sispakcf.Models;

namespace Sispakcf.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        this.BindingContext = new LoginPageViewModel();
    }
}


public partial class LoginPageViewModel : ViewModelBase
{
    public UserLogin Model { get; set; } = new UserLogin();
    public LoginPageViewModel()
    {
        ShowUrlCommand = new Command(x => ShowUrl = !ShowUrl);
    }

    [RelayCommand]
    public async Task Login()
    {
        try
        {
            var success = await Account.LoginAsync(Model);
            if (success)
            {
                Application.Current.MainPage = new AppShell();
                return;
            }

            throw new SystemException("Maaf Anda Tidak Memiliki Akses !");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }
    [RelayCommand]
    public async Task GoogleLogin()
    {
        try
        {
            var success = await Account.LoginAsync(Model);
            if (success)
            {
                Application.Current.MainPage = new AppShell();
                return;
            }

            throw new SystemException("Maaf Anda Tidak Memiliki Akses !");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    public Task Register()
    {
        Application.Current.MainPage = new RegisterPage();
        return Task.CompletedTask;
    }

    private string url = Helper.Url;

    public string URL
    {
        get { return url; }
        set { SetProperty(ref url , value);
            if (!string.IsNullOrEmpty(value))
            {
                Helper.Url = value;
            }
        }
    }

    public Command ShowUrlCommand { get; }

    [ObservableProperty]
    private bool showUrl;



}