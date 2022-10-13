using CommunityToolkit.Mvvm.ComponentModel;
using Sispakcf.Models;
using System.Collections.ObjectModel;

namespace Sispakcf.Pages;

public partial class HasilPage : ContentPage
{
	public HasilPage()
	{
		InitializeComponent();
	}
}



public partial class HasilViewModel	  :ViewModelBase
{
	private List<Jawaban> _jawabans;

	public ObservableCollection<Hasil> Results { get; private set; }
	public Command SaveCommand { get; }
	public Command CancelCommand { get; }

	public HasilViewModel(IEnumerable<Hasil> hasils, List<Jawaban> jawabans, bool canSave)
	{
		if (canSave)
			ShowSaveButton = true;
		_jawabans = jawabans;
		Results = new ObservableCollection<Hasil>(hasils.Where(x=>x.Nilai>0.0).OrderByDescending(x=>x.Nilai));
		SaveCommand = new Command(SaveAction, (x => hasils != null && hasils.Count() > 0));
		CancelCommand = new Command(x => Shell.Current.Navigation.PopModalAsync());
	}

	private async void SaveAction(object obj)
	{
		try
		{
			var result = await Pasien.SaveHistory(_jawabans);
			if (result != null)
			{
				await Shell.Current.DisplayAlert("Success","Berhasil !","Close");
				await Shell.Current.Navigation.PopModalAsync();
			}
		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert("Error", ex.Message,"Close");
		}
	}

	[ObservableProperty]
	private bool showSaveButton;


}