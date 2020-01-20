using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject.Find("CamFollow").transform.position = respawnPoint.transform.position;
            collision.transform.position = respawnPoint.transform.position;
            GameObject.Find("CamFollow").transform.position = respawnPoint.transform.position;
            Wizard.damageDealt(1);
        }
    }


}
