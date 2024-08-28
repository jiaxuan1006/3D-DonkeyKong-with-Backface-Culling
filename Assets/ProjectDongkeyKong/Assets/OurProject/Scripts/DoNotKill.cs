using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotKill : MonoBehaviour
{
    public string sceneName; // Variable to store the scene name

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == sceneName)
        {
            Destroy(this.gameObject);
        }
    }
}
