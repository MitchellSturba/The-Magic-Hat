using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Jump();
    }

    //void Jump()
    //{
    //    gameObject.GetComponent<Animator>().SetBool("SlimeJ");

    //    Invoke("Jump",4f);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag.Equals("Player"))
        {

            Wizard.damageDealt(1);
            //Vector3 moveDirection = collision.transform.position - this.transform.position;
            collision.transform.GetComponent<Wizard>().KnockBack(transform);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600);
        }
    }
}
