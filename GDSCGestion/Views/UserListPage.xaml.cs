using GDSCGestion.ViewModels;
using Microsoft.Maui.Controls.Internals;
using ZXing;
using ZXing.Net.Maui;

namespace GDSCGestion.Views;

public partial class UserListPage : ContentPage
{
    UserListPageViewModel ViewModel;
    private bool isGetData = false;
	public UserListPage(UserListPageViewModel viewModel)
	{
		InitializeComponent();
        ViewModel = viewModel;
        BindingContext = ViewModel;
        ZScanner.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode
        };
      
    }

    private void ZScanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        ZScanner.IsDetecting = false;
       App.Current.Dispatcher.Dispatch(async () =>
        {
            if (!ViewModel.databaseManager.ExisteElement(e.Results[0].Value).Result)
                await DisplayAlert("Ajout", $"Le numéro : {e.Results[0]?.Value} n'existe pas dans la base.", "Ok");
            else
                await DisplayAlert("Erreur", $"La numéro : {e.Results[0]?.Value} existe dans la base.", "Ok");
            ZScanner.IsDetecting = true;
          //  ViewModel.UpdateViewCommand.Execute(true);
        });
        //ViewModel.UpdateViewCommand.Execute(false);

        if (!ViewModel.databaseManager.ExisteElement(e.Results[0].Value).Result)
        {
            ViewModel.AddPassageCommand.Execute(new Models.UserPassage()
            {
                Code = e.Results[0].Value,
                DatePassage = DateTime.Now
            });
        }
        else
        {
            SetCollectionState(e.Results[0].Value);
        }
    }

   

    private void SetCollectionState(string code)
    {
            var item = ViewModel.databaseManager.GetElementWithCode(code).Result;
            MyListView.SelectedItem = item;
            MyListView.ScrollTo(item, animated: true, position : ScrollToPosition.Center);
    }
}