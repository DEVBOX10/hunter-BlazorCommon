using BlazorCommon.RazorLib.BackgroundTaskCase;
using BlazorCommon.RazorLib.Clipboard;
using BlazorCommon.RazorLib.Dialog;
using BlazorCommon.RazorLib.Drag;
using BlazorCommon.RazorLib.Dropdown;
using BlazorCommon.RazorLib.Notification;
using BlazorCommon.RazorLib.Options;
using BlazorCommon.RazorLib.Storage;
using BlazorCommon.RazorLib.Store.ApplicationOptions;
using BlazorCommon.RazorLib.Store.DialogCase;
using BlazorCommon.RazorLib.Store.DropdownCase;
using BlazorCommon.RazorLib.Store.NotificationCase;
using BlazorCommon.RazorLib.Store.ThemeCase;
using BlazorCommon.RazorLib.Theme;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Store.TreeViewCase;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorCommon.RazorLib;

public record BlazorCommonFactories
{
    public Func<IServiceProvider, IDragService> DragServiceFactory { get; init; } = 
        serviceProvider => new DragService(true);
    
    public Func<IServiceProvider, IClipboardService> ClipboardServiceFactory { get; init; } =
        serviceProvider => new JavaScriptInteropClipboardService(
            true,
            serviceProvider.GetRequiredService<IJSRuntime>());
    
    public Func<IServiceProvider, IDialogService> DialogServiceFactory { get; init; } =
        serviceProvider => new DialogService(
            true,
            serviceProvider.GetRequiredService<IDispatcher>(),
            serviceProvider.GetRequiredService<IState<DialogRecordsCollection>>());
    
    public Func<IServiceProvider, INotificationService> NotificationServiceFactory { get; init; } =
        serviceProvider => new NotificationService(
            true,
            serviceProvider.GetRequiredService<IDispatcher>(),
            serviceProvider.GetRequiredService<IState<NotificationRecordsCollection>>());
    
    public Func<IServiceProvider, IDropdownService> DropdownServiceFactory { get; init; } =
        serviceProvider => new DropdownService(
            true,
            serviceProvider.GetRequiredService<IDispatcher>(),
            serviceProvider.GetRequiredService<IState<DropdownsState>>());
    
    public Func<IServiceProvider, IStorageService> StorageServiceFactory { get; init; } =
        serviceProvider => new LocalStorageService(
            true,
            serviceProvider.GetRequiredService<IJSRuntime>());
    
    public Func<IServiceProvider, IAppOptionsService> AppOptionsServiceFactory { get; init; } =
        serviceProvider => new AppOptionsService(
            true,
            serviceProvider.GetRequiredService<IState<AppOptionsState>>(),
            serviceProvider.GetRequiredService<IState<ThemeRecordsCollection>>(),
            serviceProvider.GetRequiredService<IDispatcher>(),
            serviceProvider.GetRequiredService<IStorageService>());

    public Func<IServiceProvider, IThemeService> ThemeServiceFactory { get; init; } =
        serviceProvider => new ThemeService(
            true,
            serviceProvider.GetRequiredService<IState<ThemeRecordsCollection>>(),
            serviceProvider.GetRequiredService<IDispatcher>());
    
    public Func<IServiceProvider, ITreeViewService> TreeViewServiceFactory { get; init; } =
        serviceProvider => new TreeViewService(
            true,
            serviceProvider.GetRequiredService<IState<TreeViewStateContainer>>(),
            serviceProvider.GetRequiredService<IDispatcher>(),
            serviceProvider.GetRequiredService<IBackgroundTaskQueue>());
}