using CommunityToolkit.Mvvm.Input;
using GDSCGestion.IServices;
using GDSCGestion.Models;
using System.Collections.ObjectModel;

namespace GDSCGestion.ViewModels;

public partial class UserListPageViewModel : ObservableObject
{
	public IDatabaseManager<UserPassage> databaseManager;

	[ObservableProperty]
	bool isGettingData;

	[ObservableProperty]
	bool isBusy;


	public ObservableCollection<UserPassage> UserPassages { get; set; } = new();

	private void RefreshData()
	{
		Task.Run(() =>
		{
			var data = databaseManager.GetAllElements().Result.ToList();
			UserPassages.Clear();
			data.ForEach(x => UserPassages.Add(x));
		});
    }

	public UserListPageViewModel(IDatabaseManager<UserPassage> manager)
	{
		databaseManager = manager;
		UserPassages = new ObservableCollection<UserPassage>();
		RefreshData();
	}

	[RelayCommand]
	async Task AddPassage(UserPassage passage)
	{
		if (IsBusy)
			return;
		await databaseManager.AddElement(passage);
		RefreshData();
	}
	
	[RelayCommand]
	async Task UpdateView(bool rep)
	{
		if (IsBusy)
			return;
		App.Current.Dispatcher.Dispatch(() =>
		{
			IsGettingData = rep;
		});
	}


	[RelayCommand]
	async Task FillData()
	{
		RefreshData();
	}


}
