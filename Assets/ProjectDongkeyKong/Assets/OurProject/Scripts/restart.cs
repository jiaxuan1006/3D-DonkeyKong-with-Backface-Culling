using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour
{
    private ScoreManager scoreReset;
    // Start is called before the first frame update
    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("OurProject_1.4");
    }
}
