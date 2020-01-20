using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportPotion : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(0,0,50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Wizard.numTeleports = 5;
            GameObject.Find("TeleportText").GetComponent<TextMeshProUGUI>().text = Wizard.numTeleports.ToString();
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Wizard>().changeColour(0.3773585f,0.3773585f,0.3773585f,1f);
        }
    }

}
