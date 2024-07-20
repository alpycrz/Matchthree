using Events;
using UI.Utils;
using Zenject;

namespace UI.Main
{
    public class PauseBTN : UIBTN
    {
        [Inject] private MainUIEvents MainUIEvents { get; set; }
        protected override void OnClick() => MainUIEvents.PauseBTN?.Invoke();
    }
}