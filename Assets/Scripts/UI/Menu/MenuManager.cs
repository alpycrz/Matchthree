using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class MenuManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(sceneName: "Main");
        }
    }
}
