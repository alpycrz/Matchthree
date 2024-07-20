using UI.Utils;
using UnityEngine.SceneManagement;

namespace UI.Main.PausePanel
{
    public class ReturnMenuBTN : UIBTN
    {
        private void ReturnMenu() => SceneManager.LoadScene("Menu");
        protected override void OnClick() => ReturnMenu();
    }
}
