using UnityEngine;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour
{
    private bool isPaused = false;
    public Text buttonText;
   
    public void OnClick()
    {
        if (!isPaused)
        {
            buttonText.text = "Resume";
            Time.timeScale = 0.0f;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            buttonText.text = "Pause";
            isPaused = false;
        }
    }
}
