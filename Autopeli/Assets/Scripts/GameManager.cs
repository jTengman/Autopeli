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
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI PBText;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI SilverText;
    public TextMeshProUGUI BronzeText;
    private int money;
    public UnityEvent<GameManager> OnStarCollected;
    // Start is called before the first frame update
    void Start()
    {
        //starText = GetComponent<TextMeshProUGUI>();
        money = 0;
        starText.text = money.ToString();
        timerStarted = false;
        timer = false;
        curTime = 0.0f;
        GoldText.text = FormatTime(leveltimes.GoldTime);
        SilverText.text = FormatTime(leveltimes.SilverTime);
        BronzeText.text = FormatTime(leveltimes.BronzeTime);
        PBText.text = FormatTime(leveltimes.PBTime);
        UpdateTimer();
    }

    public void StarCollected()
    {
        money += 100;
        starText.text = money.ToString();
        OnStarCollected.Invoke(this);
    }

    private void Update()
    {
        if (Input.anyKey && !timerStarted)
        {
            timerStarted = true;
            timer = true;
        }
        if (timer)
        {
            curTime += Time.deltaTime;
            UpdateTimer();
        }
    }
    private void UpdateTimer()
    {
        timerText.text = FormatTime(curTime);
    }

    private string FormatTime(float time)
    {
        string timeString;
        int mins = (int)time / 60 % 60;
        float secs = curTime % 60;
        timeString = mins + ":" + secs.ToString("00.000"); // .Replace(",",":")
        return timeString;
    }

    public void LevelComplete()
    {
        timer = false;
        levelCompleteText.gameObject.SetActive(true);
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
