using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool timerStarted;
    private bool timer;
    public float curTime;
    public LevelTimes leveltimes;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI InfoText;
    public TextMeshProUGUI PBText;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI SilverText;
    public TextMeshProUGUI BronzeText;
    private int money;
    //public UnityEvent<GameManager> OnStarCollected;
    // Start is called before the first frame update
    void Start()
    {
        //starText = GetComponent<TextMeshProUGUI>();
        //PlayerPrefs.DeleteAll();
        WheelController wc = GetComponent<WheelController>();
        if (PlayerPrefs.HasKey("MaxSpeed"))
        {
            wc.maxSpeed = PlayerPrefs.GetFloat("MaxSpeed");
        }
        if (PlayerPrefs.HasKey("Acceleration"))
        {
            wc.acceleration = PlayerPrefs.GetFloat("Acceleration");
        }

        /*
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 10000);
        }
        */

        money = PlayerPrefs.GetInt("Money");
        starText.text = money.ToString();
        timerStarted = false;
        timer = false;
        curTime = 0.0f;
        InfoText.gameObject.SetActive(true);
        GoldText.text = FormatTime(leveltimes.GoldTime);
        SilverText.text = FormatTime(leveltimes.SilverTime);
        BronzeText.text = FormatTime(leveltimes.BronzeTime);
        if (SceneManager.GetActiveScene().buildIndex.Equals(1))
        {
            PBText.text = FormatTime(PlayerPrefs.GetFloat("PB1"));
            InfoText.text = "Controls: \n W - Drive forward \n A - Turn Left\n D - Turn Right \nS - Drive backwards \nSpace - Brake\n R - Reset car to last Checkpoint";
        }
        else if (SceneManager.GetActiveScene().buildIndex.Equals(2))
        {
            PBText.text = FormatTime(PlayerPrefs.GetFloat("PB2"));
            InfoText.text = "Hint:\nAs your truck gets more powerful,\nit also becomes harder to control.\nGetting the best time might be easier\nwith less powerful truck";
        }
        else if (SceneManager.GetActiveScene().buildIndex.Equals(3))
        {
            PBText.text = FormatTime(PlayerPrefs.GetFloat("PB3"));
            InfoText.text = "Hint:\nThere might be hidden ramps\n or passages\n in some levels.";
        }
        UpdateTimer();
    }

    public void InvaderHit()
    {
        money += 100;
        starText.text = money.ToString();
        //OnStarCollected.Invoke(this);
    }

    public void TentHit()
    {
        money += 300;
        starText.text = money.ToString();
        //OnStarCollected.Invoke(this);
    }

    private void Update()
    {
        if (Input.anyKey && !timerStarted)
        {
            timerStarted = true;
            timer = true;
            InfoText.gameObject.SetActive(false);
        }
        if (timer)
        {
            curTime += Time.deltaTime;
            UpdateTimer();
        }
    }
    private void UpdateTimer()
    {
        if (curTime < leveltimes.GoldTime)
        {
            timerText.color = new Color32(241,239,8, 255);
        }
        else if (curTime < leveltimes.SilverTime)
        {
            timerText.color = new Color32(199, 182, 226, 255);
        }
        else if (curTime < leveltimes.BronzeTime)
        {
            timerText.color = new Color32(236, 111, 23, 255);
        }
        timerText.text = FormatTime(curTime);
    }

    private string FormatTime(float time)
    {
        string timeString;
        int mins = (int)time / 60 % 60;
        float secs = time % 60;
        timeString = mins + ":" + secs.ToString("00.000"); // .Replace(",",":")
        return timeString;
    }

    public void LevelComplete()
    {
        if (timer)
        {
            timer = false;
            if (curTime <= leveltimes.GoldTime)
            {
                InfoText.text = "Level Complete! \n You got a Gold Medal! \nAmazing!!!";
            }
            else if (curTime <= leveltimes.SilverTime)
            {
                InfoText.text = "Level Complete! \n You got a Silver Medal! \nWay to go!";
            }
            else if (curTime <= leveltimes.BronzeTime)
            {
                InfoText.text = "Level Complete! \n You got a Bronze Medal! \nCongratulations!";
            }
            if (SceneManager.GetActiveScene().buildIndex.Equals(1))
            {
                if (curTime < PlayerPrefs.GetFloat("PB1") || !PlayerPrefs.HasKey("PB1"))
                {
                    InfoText.text += "\n\nNew Personal Best!!! Wow!!";
                    PlayerPrefs.SetFloat("PB1", curTime);
                }
            }
            if (SceneManager.GetActiveScene().buildIndex.Equals(2))
            {
                if (curTime < PlayerPrefs.GetFloat("PB2") || !PlayerPrefs.HasKey("PB2"))
                {
                    InfoText.text += "\n\nNew Personal Best!!! Wow!!";
                    PlayerPrefs.SetFloat("PB2", curTime);
                }
            }
            if (SceneManager.GetActiveScene().buildIndex.Equals(3))
            {
                if (curTime < PlayerPrefs.GetFloat("PB3") || !PlayerPrefs.HasKey("PB3"))
                {
                    InfoText.text += "\n\nNew Personal Best!!! Wow!!";
                    PlayerPrefs.SetFloat("PB3", curTime);
                }
            }

            InfoText.gameObject.SetActive(true);
            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("Money", money);
        SceneManager.LoadScene(0);
    }
}
