
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Font = Microsoft.Maui.Font;

namespace SnackbarCheck.Services;

public class MessageService : IMessageService
{
    public async Task ShowSnackbarMessage(string message, string okButtonText = "Ok", int durationInMS = 2500, CancellationTokenSource cancellationTokenSource = null)
    {
        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            ActionButtonTextColor = Colors.Blue,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14)
        };

        var snackbar = Snackbar.Make(message, null, okButtonText, TimeSpan.FromMilliseconds(durationInMS), snackbarOptions);

        await DisplaySnackbarSafely(snackbar, cancellationTokenSource);
    }

    public async Task ShowToast(string message, ToastDuration duration = ToastDuration.Short, CancellationTokenSource cancellationTokenSource = null)
    {
        var toast = Toast.Make(message, duration);
        if (Application.Current!.Dispatcher.IsDispatchRequired)
        {
            await Application.Current.Dispatcher.DispatchAsync(async () => await toast.Show(cancellationTokenSource?.Token ?? CancellationToken.None));
        }
        else
        {
            await toast.Show(cancellationTokenSource?.Token ?? CancellationToken.None);
        }
    }

    private async Task DisplaySnackbarSafely(ISnackbar snackbar, CancellationTokenSource cancellationTokenSource)
    {
        await Application.Current!.Dispatcher.DispatchAsync(async () =>
        {
            await snackbar.Show(cancellationTokenSource?.Token ?? CancellationToken.None);
        });
    }
}
