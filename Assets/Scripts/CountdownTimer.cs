using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float countDownTime = 10f;

    private Image countdownImage;

    private float timeLeft;

    void Start()
    {
        countdownImage = GetComponent<Image>();
        timeLeft = countDownTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            countdownImage.fillAmount = timeLeft / countDownTime;
        }
        else
        {
            countdownImage.fillAmount = 0;

            GameManager.instance.isTimeUp = true;
        }
    }
}
