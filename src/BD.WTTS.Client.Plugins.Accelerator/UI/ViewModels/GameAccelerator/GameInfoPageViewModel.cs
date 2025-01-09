using BD.WTTS.Helpers;

namespace BD.WTTS.UI.ViewModels;

public sealed class GameInfoPageViewModel : WindowViewModel
{
    [Reactive]
    public XunYouGameViewModel XunYouGame { get; set; }

    [Reactive]
    public bool IsShowSelectServerUI { get; set; }

    public GameInfoPageViewModel(XunYouGameViewModel xunYouGame)
    {
        XunYouGame = xunYouGame;

        this.WhenPropertyChanged(x => x.XunYouGame.SelectedArea, true)
            .Where(x => x.Value != null && x.Value.Servers.Any_Nullable())
            .Subscribe(x => IsShowSelectServerUI = true);
    }

    public void BackSelectArea()
    {
        IsShowSelectServerUI = false;
        XunYouGame.SelectedArea = null;
        XunYouGame.SelectedServer = null;
    }

    public void ImmediatelyAccelerate()
    {
        if (XunYouGame.SelectedArea == null)
        {
            Toast.Show(ToastIcon.Warning, Strings.GameAccelerator_AccelerateAreaSelectTip);
            return;
        }

        if (XunYouGame.SelectedArea.Servers.Any_Nullable() && XunYouGame.SelectedServer == null)
        {
            Toast.Show(ToastIcon.Warning, Strings.GameAccelerator_AccelerateAreaSelectTip);
            return;
        }

        TracepointHelper.TrackEvent(nameof(ImmediatelyAccelerate), new Dictionary<string, string> {
                { "GameId", XunYouGame.Id.ToString() },
                { "GameName", XunYouGame.Name ?? string.Empty },
                { "SelectedArea", XunYouGame?.SelectedArea?.Name ?? string.Empty },
                { "SelectedServer", XunYouGame?.SelectedServer?.Name ?? string.Empty },
            });

        Close?.Invoke(true);
    }
}
