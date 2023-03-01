using BlazorCommon.RazorLib.Dialog;
using BlazorCommon.RazorLib.Drag;
using BlazorCommon.RazorLib.Dropdown;
using BlazorCommon.RazorLib.Notification;
using BlazorCommon.RazorLib.Options;
using BlazorCommon.RazorLib.Storage;
using BlazorCommon.RazorLib.Theme;
using BlazorCommon.RazorLib.TreeView;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCommon.RazorLib;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The <see cref="configure"/> parameter provides an instance of a record type. Use the 'with' keyword to
    /// change properties and then return the new instance.
    /// </summary>
    public static IServiceCollection AddBlazorCommonServices(
        this IServiceCollection services,
        Func<BlazorCommonOptions, BlazorCommonOptions>? configure = null)
    {
        var blazorCommonOptions = new BlazorCommonOptions();

        configure?.Invoke(blazorCommonOptions);
        
        return services
            .AddSingleton<BlazorCommonOptions>(blazorCommonOptions)
            .AddScoped<IDialogService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.DialogServiceFactory.Invoke(serviceProvider))
            .AddScoped<INotificationService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.NotificationServiceFactory.Invoke(serviceProvider))
            .AddScoped<IDragService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.DragServiceFactory.Invoke(serviceProvider))
            .AddScoped<IDropdownService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.DropdownServiceFactory.Invoke(serviceProvider))
            .AddScoped<IAppOptionsService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.AppOptionsServiceFactory.Invoke(serviceProvider))
            .AddScoped<IStorageService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.StorageServiceFactory.Invoke(serviceProvider))
            .AddScoped<IThemeService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.ThemeServiceFactory.Invoke(serviceProvider))
            .AddScoped<ITreeViewService>(serviceProvider => 
                blazorCommonOptions.BlazorCommonFactories.TreeViewServiceFactory.Invoke(serviceProvider));
    }
}