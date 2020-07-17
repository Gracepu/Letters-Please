using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void QuitApplication() {
        Application.Quit();
    }
}

