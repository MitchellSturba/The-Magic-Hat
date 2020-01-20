using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkeletonScript : MonoBehaviour
{

    private int health = 3;
    Vector2 PointA;
    Vector2 PointB;
    Animator myAnim;
    bool walkToA = false, walkToB = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = transform.GetComponent<Animator>();

        //getting patrol parameters
        PointA = transform.position;
        PointA.x -= 2;
        PointB = transform.position;
        PointB.x += 2;

        Invoke("PatrolA",3);
    }

    void PatrolA()
    {
        if (!attacking)
        {
            myAnim.SetTrigger("Walking");
            walkToB = false;
            walkToA = true;
        }
    }

    void PatrolB()
    {
        if (!attacking)
        {
            myAnim.SetTrigger("Walking");
            walkToA = false;
            walkToB = true;
        }
    }

    public void Die()
    {
        myAnim.SetTrigger("Dead");
        walkToA = false;
        walkToB = false;
        Destroy(this);
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = false;
        transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;

        GameObject EneKilledUIText = GameObject.Find("EnemiesKilledUIText");
        int enKilledInt = int.Parse(EneKilledUIText.GetComponent<TextMeshProUGUI>().text);
        enKilledInt++;
        EneKilledUIText.GetComponent<TextMeshProUGUI>().text = enKilledInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position,Vector3.right,out hit, 10))
        //{

        //}

        if (walkToA && transform.position.x > PointA.x)
        {
            transform.Translate(Vector2.left * Time.deltaTime);
            transform.localScale = new Vector3(-1,1,1);
        }else if (transform.position.x <= PointA.x)
        {
            myAnim.SetTrigger("Idle");
            Invoke("PatrolB",3f);
            walkToA = false;
        }

        if (walkToB && transform.position.x < PointB.x)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x >= PointB.x)
        {
            myAnim.SetTrigger("Idle");
            Invoke("PatrolA", 3f);
            walkToB = false;
        }

    }

    void attackPlayer() {

        if (GameObject.FindWithTag("Player").transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        myAnim.Play("Attack");
        myAnim.SetTrigger("Attack");
        Invoke("checkHitPlayer",0.4f);
        Invoke("endAttack",1.2f);
    }

    void endAttack()
    {
        attacking = false;
    }

    void checkHitPlayer()
    {
        if (SkeletonWeapon.WizardHit)
        {
            Wizard.damageDealt(1);
            GameObject.FindWithTag("Player").GetComponent<Wizard>().KnockBack(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("PatrolA", 2f);

    }

    bool attacking = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !attacking)
        {
            attacking = true;
            walkToA = false;
            walkToB = false;
            attackPlayer();
            Debug.Log("PLAYER DETECTED");
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled", 0) + 1);
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player"))
    //    {
    //        attacking = true;
    //        walkToA = false;
    //        walkToB = false;
    //        attackPlayer();
    //        Debug.Log("PLAYER DETECTED");
    //    }
    //}
}
