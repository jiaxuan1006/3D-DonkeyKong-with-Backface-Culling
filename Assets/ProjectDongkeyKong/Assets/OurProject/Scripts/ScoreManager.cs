using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreComplete;
    public TextMeshProUGUI highScoreText;
    int scoreCount = 0;
    public static int highScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCount > highScoreCount )
        {
            highScoreCount = scoreCount;
            if(ThirdPersonController.statusGame == true)
            {
                PlayerPrefs.SetInt("HighScore", highScoreCount);
                Debug.Log(ThirdPersonController.statusGame);

            }
        }

        scoreText.text = scoreCount.ToString();
        scoreComplete.text = scoreText.text;
        Debug.Log(scoreComplete.text);
        highScoreText.text = highScoreCount.ToString();      
    }

    public void addScore(int score)
    {
        scoreCount = scoreCount + score;
    }
}
