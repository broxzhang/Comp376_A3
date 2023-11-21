using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replay()
    {
        SceneManager.LoadScene("PumpkinRun");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameManager.instance.isGameStarted = true;
        GameManager.instance.startPanel.SetActive(false);
    }
}
