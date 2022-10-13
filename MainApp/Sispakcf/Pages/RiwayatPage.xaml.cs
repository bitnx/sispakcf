using Sispakcf.Models;
using System.Collections.ObjectModel;

namespace Sispakcf.Pages;

public partial class RiwayatPage : ContentPage
{
	public RiwayatPage()
	{
		InitializeComponent();
        BindingContext = new RiwayatViewModel();
    }
}

internal class RiwayatViewModel : ViewModelBase
{
    public ObservableCollection<Konsultasi> SourceView { get; set; } = new ObservableCollection<Konsultasi>();

    public RiwayatViewModel()
    {
        LoadCommand = new Command(async (x) => await LoadAction(x));
        SubmitCommand = new Command(async (x) => await SubmitAction(x));
        LoadCommand.Execute(null);
    }

    private async Task SubmitAction(object x)
    {
        try
        {
            var konsultasi = (Konsultasi)x;
            var jawabans = konsultasi.GejalaPasien;

            var result = await SolusiAndGejala.Calculate(jawabans.ToList());

            var vm = new HasilViewModel(result, jawabans.ToList(), false);
            var page = new HasilPage { BindingContext = vm };
            await Shell.Current.Navigation.PushModalAsync(page);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Close");
        }

    }

    public Command LoadCommand { get; }

    private async Task LoadAction(object x)
    {
        try
        {
            if (IsBusy)
                return;
            IsBusy = true;

            var results = await Pasien.GetHistoriesAsync();
            SourceView.Clear();
            foreach (var item in results)
            {
                SourceView.Add(item);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Close");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private Command submitCommand;

    public Command SubmitCommand
    {
        get { return submitCommand; }
        set { SetProperty(ref submitCommand, value); }
    }



}