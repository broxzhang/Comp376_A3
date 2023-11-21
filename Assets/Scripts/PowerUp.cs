using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int RandomNumber = Random.Range(0, 100);

        Debug.Log(RandomNumber);
        if (RandomNumber >= 30)
        {
            Destroy(gameObject);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 , 60 * Time.deltaTime, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
            if (gameObject.tag == "Power_One") {
                Debug.Log("Power One");
                GameManager.instance.OneTimeShield++;
            } else if (gameObject.tag == "Power_Two") {
                Debug.Log("Power Two");
            } else if (gameObject.tag == "Power_Three") {
                GameManager.instance.HugePumpkinRoll = true;
                Debug.Log("Power Three");
            } else if (gameObject.tag == "Power_Four") {
                Debug.Log("Power Four");
                GameManager.instance.SupperFlyPumpkin = true;
            } else if (gameObject.tag == "Power_Five") {
                Debug.Log("Power Five");
            } else {
                return;
            }
        }
    }
}
