using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;
    public bool isGameOver;

    public GameObject gameOverPanel;

    public GameObject playerPanel;

    public GameObject startPanel;

    public bool PermenantPowerUp_One = false;

    public bool PermenantPowerUp_Two = false;

    public int OneTimeShield = 0;

    public bool HugePumpkinRoll = false;

    public bool SupperFlyPumpkin = false;

    public int score = 0;

    public bool isTimeUp = false;

    public bool isGameStarted = false;

    void Start()
    {
        isGameOver = false;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.timeScale = 0;
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

    }
}
