
using CommunityToolkit.Maui.Core;

namespace SnackbarCheck.Services;

public interface IMessageService
{
    public Task ShowToast(string message, ToastDuration duration = ToastDuration.Short, CancellationTokenSource cancellationTokenSource = null);
    public Task ShowSnackbarMessage(string message, string okButtonText = "Ok", int durationInMS = 2500, CancellationTokenSource cancellationTokenSource = null);
}
