using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool timer;
    float curTime;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI starText;
    private int starsCollected;
    public UnityEvent<GameManager> OnStarCollected;
    // Start is called before the first frame update
    void Start()
    {
        //starText = GetComponent<TextMeshProUGUI>();
        starsCollected = 0;
        starText.text = starsCollected.ToString();
        timer = false;
        curTime = 0.0f;
        UpdateTimer();
    }

    public void StarCollected()
    {
        starsCollected++;
        starText.text = starsCollected.ToString();
        OnStarCollected.Invoke(this);
    }

    private void Update()
    {
        if (timer)
        {
            curTime += Time.deltaTime;
            UpdateTimer();
        }
    }
    private void UpdateTimer()
    {
        string timeString;
        int mins = (int)curTime / 60 % 60;
        float secs = curTime % 60;
        timeString = mins + ":" + secs.ToString("00.000"); // .Replace(",",":")
        timerText.text = timeString;
    }
}
