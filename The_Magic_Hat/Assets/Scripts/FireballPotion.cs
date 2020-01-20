using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballPotion : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(0, 0, 30 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Wizard.numFireballs+= 3;
            GameObject.Find("FireballText").GetComponent<TextMeshProUGUI>().text = Wizard.numFireballs.ToString();
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Wizard>().changeColour(1f,0.3537736f,0.9348505f,1f);
        }
    }

}
