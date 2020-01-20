using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserPotion : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(0,0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject.Find("LaserTimeText").GetComponent<TextMeshProUGUI>().text = "Laser Time: 30";
            Wizard.laserEyes = true;
            Wizard.oneOFF = true;
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Wizard>().changeColour(0.5f,1f,0.5f,1f);
        }
    }

}
