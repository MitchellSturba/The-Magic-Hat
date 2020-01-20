using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Rigidbody2D rb;
    public float flightspeed;
    bool flyRight = true;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (GameObject.Find("Wizard").transform.localScale.x < 0)
        {
            rb.velocity = new Vector2(-flightspeed, 0);
            transform.localScale = new Vector3(.6f, .6f, 1);
            flyRight = false;
        }
        else rb.velocity = new Vector2(flightspeed, 0);
    }
    // Update is called once per frame
    public void update()
    {
        //Debug.Log("test");
        if (flyRight) { 
            rb.velocity = new Vector2(-flightspeed,0);
        }
        else rb.velocity = new Vector2(-flightspeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Collider with " + collision.transform.name);
        if (!collision.name.Equals("Detector"))Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Collider with " + collision.transform.name);
        if (!collision.transform.name.Equals("Detector")) Destroy(gameObject);
    }
}
