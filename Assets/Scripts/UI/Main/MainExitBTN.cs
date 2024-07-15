using Events;
using UI.Utils;


namespace UI.Main
{
    public class MainExitBTN : UIBTN
    {
        protected override void OnClick() => MainUIEvents.ExitBTN?.Invoke();
    }
}
