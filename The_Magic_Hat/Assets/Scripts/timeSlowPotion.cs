using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeSlowPotion : MonoBehaviour
{
    bool colleced = false;
    private void Update()
    {
        transform.Rotate(0,0,50 * Time.deltaTime);
        //if (colleced)transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Time.timeScale = 0.5f;
            timeLeft = 5;
            Invoke("NormTime",5f);
            CountDown();
            gameObject.SetActive(false);
            colleced = true;
            transform.parent = null;
             GameObject.FindWithTag("Player").GetComponent<Wizard>().changeColour(.5f,.5f,1f,1f,5f);
        }
    }

    int timeLeft = 0;
    void CountDown()
    {
        GameObject.Find("SlowDownTimeText").GetComponent<TextMeshProUGUI>().text = timeLeft.ToString();
        timeLeft--;
        if (timeLeft >= 0) Invoke("CountDown",1);
    }

    void NormTime()
    {
        Time.timeScale = 1;
    }
}
