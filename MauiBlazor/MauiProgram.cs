using Microsoft.AspNetCore.Components.WebView.Maui;
using Data;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Services;

namespace MauiBlazor;

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
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("videogamesdb"));
        builder.Services.AddScoped<IFuenteService, FuenteService>();
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();


        return builder.Build();
	}
}
