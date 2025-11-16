using Microsoft.Extensions.Logging;

namespace CryptoKeyToolbox.UI;
using MudBlazor.Services;
using MudBlazor.ThemeManager;
using CryptoKeyToolbox.Infrastructure.Infra;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.Services.AddMauiBlazorWebView();
		builder.Services.AddMudServices();
		builder.Services.AddCryptoKeyToolboxServices();


#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
