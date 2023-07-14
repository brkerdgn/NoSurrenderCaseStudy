using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] CreatePlayer playersInfo;
    [SerializeField] TMP_Text playerText;
    [SerializeField] Animator textAnim;
    [SerializeField] GameObject canvasMenu,gameOverMenu,winMenu;
    [SerializeField] Image soundImage;
    [SerializeField] Sprite openSound, muteSound;
    bool isMute;
    float lastPlayerCount;
    [SerializeField] float playTime;
    [SerializeField] TMP_Text timeText;


    private void Update()
    {
        //Oyuncu sayýsý UI da gösterme
        playerText.text = playersInfo.totalPlayerCount.ToString();
        if (playersInfo.totalPlayerCount != lastPlayerCount)
        {
            textAnim.SetTrigger("isScale");
            lastPlayerCount = playersInfo.totalPlayerCount;
        }

        PlayTime();
        GameOverControl();
    }

    public void GameOverControl()
    {
        if ( playersInfo.isMyDead || playTime <= 0)
        {
            gameOverMenu.SetActive(true);
        }

        if (playersInfo.totalPlayerCount == 1)
        {
            winMenu.SetActive(true);
        }
    }

    public void PlayTime()
    {
        //Oyundaki süreyi burada ayarlýyoruz
        playTime -= Time.deltaTime;
        int remainingTime = Mathf.CeilToInt(playTime);

        if (remainingTime >= 0)
        {
            int minute = remainingTime / 60;
            int second = remainingTime % 60;
            timeText.text = string.Format("{0:00}:{1:00}", minute, second);
        }
        else
        {
            timeText.text = "00:00";
        }
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        canvasMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGameButton()
    {
        canvasMenu.SetActive(false);
        Time.timeScale = 1f;     
    }

    public void SoundControlButton()
    {
        if (!isMute)
        {
            soundImage.sprite = muteSound;
            isMute = true;
        }
        else
        {
            soundImage.sprite = openSound;
            isMute = false;
        }
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
