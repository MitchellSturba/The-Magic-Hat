using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_Script : MonoBehaviour
{

    float starty;

    private void Start()
    {
        starty = transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(0, 0, 80 * Time.deltaTime);
        Vector3 tmp = transform.position;
        tmp.y = starty + Mathf.PingPong(Time.time / 2, .5f);
        transform.position = tmp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerPrefs.SetInt("Collectables", PlayerPrefs.GetInt("Collectables", 0) + 1);
            Wizard.AddCollectiable(1);
            Destroy(this.gameObject);
        }
    }
}
