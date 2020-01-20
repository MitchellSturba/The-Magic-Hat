using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHead : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            //collision.transform.GetComponent<Wizard>().KnockBack(transform);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,14);
            //this.transform.parent.gameObject.SetActive(false);
            //Destroy(this.transform.parent.gameObject);
            //collision.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }
    }

}
