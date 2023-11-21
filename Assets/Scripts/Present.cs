using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Present : MonoBehaviour

{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime,  0 );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.score++;
            scoreText.text = "You collected " + GameManager.instance.score.ToString() + " presents!";
        }
    }
}
