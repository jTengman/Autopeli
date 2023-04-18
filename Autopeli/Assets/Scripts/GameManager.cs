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
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI levelCompleteText;
    private int starsCollected;
    public UnityEvent<GameManager> OnStarCollected;
    // Start is called before the first frame update
    void Start()
    {
        //starText = GetComponent<TextMeshProUGUI>();
        starsCollected = 0;
        starText.text = starsCollected.ToString();
        timerStarted = false;
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
        string timeString;
        int mins = (int)curTime / 60 % 60;
        float secs = curTime % 60;
        timeString = mins + ":" + secs.ToString("00.000"); // .Replace(",",":")
        timerText.text = timeString;
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
