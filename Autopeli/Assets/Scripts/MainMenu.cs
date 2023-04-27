using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI MoneyValue;
    public TextMeshProUGUI MaxSpeedValue;
    public TextMeshProUGUI MaxSpeedCost;
    public TextMeshProUGUI AccelerationValue;
    public TextMeshProUGUI AccelerationCost;
    public GameObject AccPlusButton;
    public GameObject AccMinusButton;
    public GameObject SpeedPlusButton;
    public GameObject SpeedMinusButton;
    private float[] MaxSpeeds;
    private float[] Accelerations;
    private int[] Costs;
    private int Money;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MaxSpeedIndex"))
        {
            PlayerPrefs.SetInt("MaxSpeedIndex", 0);
        }
        if (!PlayerPrefs.HasKey("AccelerationIndex"))
        {
            PlayerPrefs.SetInt("AccelerationIndex", 0);
        }
        
        MaxSpeeds =     new float[]  { 20f,     22f,    24f,    26f,    28f,    30f };
        Accelerations = new float[]  { 200f,   250f,   300f,   350f,   400f,    450f };
        Costs =          new int[]   { 1000,    1100,   1200,   1300,   1400,   9999 };
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UpdateValues();
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit-button pressed");
    }

    public void IncreaseMaxSpeed()
    {
        int index = PlayerPrefs.GetInt("MaxSpeedIndex");
        if (Money > Costs[index] && index < MaxSpeeds.Length-1)
        {
            Money -= Costs[index];
            PlayerPrefs.SetInt("Money", Money);
            PlayerPrefs.SetInt("MaxSpeedIndex", index+1);
        }
        UpdateValues();
    }

    public void DecreaseMaxSpeed()
    {
        int index = PlayerPrefs.GetInt("MaxSpeedIndex");
        if (index > 0)
        {
            Money += Costs[index - 1];
            PlayerPrefs.SetInt("Money", Money);
            PlayerPrefs.SetInt("MaxSpeedIndex", index - 1);
        }
        UpdateValues();
    }

    public void IncreaseAcceleration()
    {
        int index = PlayerPrefs.GetInt("AccelerationIndex");
        if (Money > Costs[index] && index<Accelerations.Length-1)
        {
            Money -= Costs[index];
            PlayerPrefs.SetInt("Money", Money);
            PlayerPrefs.SetInt("AccelerationIndex", index + 1);
        }
        UpdateValues();
    }

    public void DecreaseAcceleration()
    {
        int index = PlayerPrefs.GetInt("AccelerationIndex");
        if (index > 0)
        {
            Money += Costs[index -1];
            PlayerPrefs.SetInt("Money", Money);
            PlayerPrefs.SetInt("AccelerationIndex", index - 1);
        }
        UpdateValues();
    }

    private void UpdateValues()
    {
        Money = PlayerPrefs.GetInt("Money");
        MoneyValue.text = Money.ToString();

        PlayerPrefs.SetFloat("MaxSpeed",MaxSpeeds[PlayerPrefs.GetInt("MaxSpeedIndex")]);
        MaxSpeedValue.text = PlayerPrefs.GetFloat("MaxSpeed").ToString();
        MaxSpeedCost.text = Costs[PlayerPrefs.GetInt("MaxSpeedIndex")].ToString();
        if (PlayerPrefs.GetInt("MaxSpeedIndex") == MaxSpeeds.Length-1)
        {
            SpeedPlusButton.SetActive(false);
        }
        else
        {
            SpeedPlusButton.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MaxSpeedIndex") == 0)
        {
            SpeedMinusButton.SetActive(false);
        }
        else
        {
            SpeedMinusButton.SetActive(true);
        }

        PlayerPrefs.SetFloat("Acceleration", Accelerations[PlayerPrefs.GetInt("AccelerationIndex")]);
        AccelerationCost.text = Costs[PlayerPrefs.GetInt("AccelerationIndex")].ToString();
        AccelerationValue.text = PlayerPrefs.GetFloat("Acceleration").ToString();
        if (PlayerPrefs.GetInt("AccelerationIndex") == Accelerations.Length-1)
        {
            AccPlusButton.SetActive(false);
        }
        else
        {
            AccPlusButton.SetActive(true);
        }
        if (PlayerPrefs.GetInt("AccelerationIndex") == 0)
        {
            AccMinusButton.SetActive(false);
        }
        else
        {
            AccMinusButton.SetActive(true);
        }
    }

}
