using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] wolves;
    public int pointThreshold = 20;
    public GameObject pnlEndgame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public TMP_Text txtPoint;
    private int gamePoint;
    private int highScore;
    public GameObject Btn;
    new AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pnlEndgame.SetActive(false);
        Btn.SetActive(true);
        audio = gameObject.GetComponent<AudioSource>();
        audio.Pause();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void GetPoint()
    {
        gamePoint++;
        IncreaseAttackSpeed();
        txtPoint.text = "Point: " + gamePoint.ToString() + "\nHighScore: " + highScore.ToString();
        if (gamePoint > highScore)
        {
            highScore = gamePoint;
            PlayerPrefs.SetInt("HighScore", gamePoint);
        }
    }

    private void IncreaseAttackSpeed()
    {
        if (gamePoint % pointThreshold == 0)
        {
            foreach (GameObject wolf in wolves)
            {
                var wolfAttribute = wolf.GetComponent<WolfController>();
                wolfAttribute.maxBoomTime = wolfAttribute.maxBoomTime / 2f;
                Debug.Log(wolfAttribute.maxBoomTime);
            }
        }
    }

    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        audio.Play();
        Time.timeScale = 0;
        pnlEndgame.SetActive(true);
        Btn.SetActive(false);
    }

}
