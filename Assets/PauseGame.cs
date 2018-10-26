using UnityEngine;

public class PauseGame : MonoBehaviour {
    public CameraMovement cm;
    public GameObject pausePanel;
    public GameObject pauseButton;
    bool temp = false;
    public void Pause()
    {
        Time.timeScale = 0f;
        cm.isCounntig = false;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        if (AudioListener.pause == false)
            AudioListener.pause = true;
        else
            temp = true;
        
    }

    public void Resume()
    {
        cm.isCounntig = true;
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        if(temp)
        {
            AudioListener.pause = true;
            return;
        }
        else if (AudioListener.pause == true)
            AudioListener.pause = false;
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
