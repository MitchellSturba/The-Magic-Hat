using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlameEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Fireball"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "FLAME TAGE");
        if (other.transform.tag.Equals("Fireball"))
        {
            PlayerPrefs.SetInt("EnemiesKilled",PlayerPrefs.GetInt("EnemiesKilled",0)+1 );
            Destroy(gameObject);

            GameObject EneKilledUIText = GameObject.Find("EnemiesKilledUIText");
            int enKilledInt = int.Parse(EneKilledUIText.GetComponent<TextMeshProUGUI>().text);
            enKilledInt++;
            EneKilledUIText.GetComponent<TextMeshProUGUI>().text = enKilledInt.ToString();
        }
    }

}
