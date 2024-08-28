using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public GameObject inGameUI, gameOver, gameComplete, life1, life2, life3, bonusComplete;
    public static int health = 3;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI bonusCompleteText;
    public static int bonusCount = 1000;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        gameComplete.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                bonusCount = 1000;
                break;

            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                bonusCount = 500;
                break;

            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                bonusCount = 300;
                break;

            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                bonusCount = 0;
                Time.timeScale = 0;
                break;


            default:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);
                Time.timeScale = 0;
                break;
        } 

          bonusText.text = bonusCount.ToString();
          bonusCompleteText.text = bonusCount.ToString();

          if(ThirdPersonController.statusGame == true)
          {
            inGameUI.gameObject.SetActive(false);
            gameComplete.gameObject.SetActive(true);
          }        
    }
}