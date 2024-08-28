using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string sceneName; // Variable to store the scene name
    public float delay = 1f; // Delay in seconds

    public void ChangeScene(string sceneName)
    {
        this.sceneName = sceneName;
        Invoke("LoadSceneWithDelay", delay);
    }

    private void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneName);
    }
}