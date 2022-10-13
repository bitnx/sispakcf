using Sispakcf.Models;
using System.Collections.ObjectModel;

namespace Sispakcf.Pages;

public partial class DiagnosaPage : ContentPage
{
	public DiagnosaPage()
	{
		InitializeComponent();
		BindingContext = new DiagnosaViewModel();
	}
}

internal class DiagnosaViewModel:ViewModelBase
{
	public ObservableCollection<Jawaban> Jawabans { get; set; } = new ObservableCollection<Jawaban>();

	public ObservableCollection<Pilihan> Pilihans { get; set; } = new ObservableCollection<Pilihan>(Enum.GetValues(typeof(Pilihan)).Cast<Pilihan>());


	public DiagnosaViewModel()
	{
		LoadCommand = new Command(async(x) => await LoadAction(x));
        SubmitCommand = new Command(async(x) => await SubmitAction(x));
		LoadCommand.Execute(null);
	}

	private async Task SubmitAction(object x)
	{
		try
		{
			var jawabans = Jawabans.Where(x => x.NilaiPilihan != Pilihan.None).OrderBy(x => x.Gejala.Id).ToList();

			var result = await SolusiAndGejala.Calculate(jawabans);

			var vm = new HasilViewModel(result, jawabans, true);
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

			var results = await SolusiAndGejala.GetGejalaAsync();
			Jawabans.Clear();
			foreach (var item in results)
			{
				Jawabans.Add(new Jawaban { Gejala = item, NilaiPilihan = Pilihan.None });
			}
		}
		catch (Exception ex)
		{
			await	Shell.Current.DisplayAlert("Error", ex.Message, "Close");
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
		set { SetProperty(ref submitCommand , value); }
	}



}