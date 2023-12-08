using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{

    public void LoadSceneByIndex()
    {
        Time.timeScale = 1.0f;
        // Load the scene with build index 0
        SceneManager.LoadScene(0);
    }
}
