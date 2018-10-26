using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CameraMovement : MonoBehaviour {

    public PlayerController p;
    private static float speed = 2.0f;
    public GameObject deathPanel;
    private static int score = 0;
    private static int tempScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;
    public TextMeshProUGUI bestScore;
    public bool isCounntig = true;
    public GameObject ReadyButton;
    private static bool isReady = false;
    public AudioSource audioSource;
    public bool startDeleteTile = false;

    private void Start()
    {
        if (isReady)
        {
            startDeleteTile = true;
            ReadyButton.SetActive(false);
            audioSource.Play();
        }
    }

    void Update () {
        if (isReady)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (!p.gameEnd && isCounntig == true)
            {
                score++;
                tempScore++;
                if (tempScore > 2000)
                {
                    if (speed < 3.5)
                    {
                        speed += 0.5f;
                    }
                    tempScore = 0;
                }
                if (score > PlayerPrefs.GetInt("BestScore"))
                {
                    PlayerPrefs.SetInt("BestScore", score);
                }
                scoreText.text = score.ToString();
            }
            if (p.gameEnd == true)
            {          
                p.gameEnd = false;
                isCounntig = false;
                speed = 0;
                StartCoroutine(wait());

            }
        }
        
	}
    IEnumerator wait()
    {
        audioSource.Pause();
        yield return new WaitForSeconds(1.0f);
        deathPanel.SetActive(true);
        deathScoreText.text = "Score : " + score.ToString();
        bestScore.text = "Best Score : " + PlayerPrefs.GetInt("BestScore").ToString();
        
    }

    public void PlayAgain()
    {
        PlayerPrefs.SetInt("ready", 2);
        isReady = false;
        speed = 2.0f;
        tempScore = 0;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        isReady = false;
        speed = 2.0f;
        score = 0;
        tempScore = 0;
        SceneManager.LoadScene(0);
    }

    public void Ready()
    {
        startDeleteTile = true;
        audioSource.Play();
        isReady = true;
        ReadyButton.SetActive(false);
        
    }
}
