using GDSCGestion.IServices;
using GDSCGestion.Models;
using GDSCGestion.Services;
using GDSCGestion.ViewModels;
using GDSCGestion.Views;

namespace GDSCGestion;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .UseMauiCommunityToolkit();

		builder.Services.AddSingleton<UserListPage>();
		builder.Services.AddSingleton<UserListPageViewModel>();
		builder.Services.AddSingleton<IDatabaseManager<UserPassage>, DatabaseManager>();
		builder.Services.AddSingleton<DatabaseManager>();

        
#if DEBUG
        builder.Logging.AddDebug();
#endif

		//builder.ConfigureMauiHandlers(h =>
		//{
		//	h.AddHandler(typeof(ZXing.Net))
		//});



		return builder.Build();
	}
}
