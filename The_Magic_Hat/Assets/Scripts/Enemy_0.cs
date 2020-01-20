using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0 : MonoBehaviour
{

    public int health = 3;
    public int walkingRight = -1;
    private bool walking = false, PatrolA = true, idleing = false, left = true;
    float walkspeed = 2.5f;
    private Animator anim;
    Vector3 PointA, PointB;

    private void Start()
    {
        PointA = transform.position;
        PointB = transform.position;

        PointA.x -= 2f;
        PointB.x += 2f;

        anim = GetComponent<Animator>();
        anim.SetBool("walking", true);
        Invoke("IdleMaybe", Random.Range(3, 5));
    }

    // Update is called once per frame
    void Update()
    {
        if (!idleing)
        {
            if (PatrolA)
            {
                if (transform.position.x > PointA.x)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * walkspeed);
                }
                else if (transform.position.x <= PointA.x && left)
                {
                    left = false;
                    switchDirection();
                    PatrolA = false;
                }
            }
            else
            {
                if (transform.position.x < PointB.x)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * walkspeed);
                }
                else if (transform.position.x >= PointB.x && !left)
                {
                    left = true;
                    switchDirection();
                    PatrolA = true;
                }
            }
        }

        //else
        //{
        //    anim.SetBool("walking",false);
        //}
    }

    void IdleMaybe()
    {
        Invoke("IdleMaybe", Random.Range(3,5));
        anim.SetBool("walking", false);
        idleing = true;
        Invoke("offIdle", 2);
    }

    void offIdle()
    {
        anim.SetBool("walking", true);
        idleing = false;
    }
    void switchDirection()
    {
        walkingRight *= -1;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Equals("Fireball_Prefab(Clone)"))
        {
            health--;
            if (health == 0) Destroy(gameObject);
        }
        if (collision.transform.tag.Equals("Player"))
        {
            Wizard.damageDealt(1);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled", 0) + 1);

    }
}
