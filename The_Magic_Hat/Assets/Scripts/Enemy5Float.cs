/*
If the wizard script needs to get over written the knock back function used for this function is:
public void KnockBack(Transform enemyPos, float hitDistance)
    {
        if (enemyPos.position.x > transform.position.x)
        {
            myRig.AddForce(Vector2.left * hitDistance *200);
            myRig.AddForce(Vector2.up * hitDistance*200 );
       }
        else
        {
            myRig.AddForce(Vector2.right * hitDistance*200);
            myRig.AddForce(Vector2.up * hitDistance *200);
        }
    }
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy5Float : MonoBehaviour
{
    public float speed;
    public float distance;
    public float hitDistance;
    bool invincible = false;

private void Start() {
    GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
    Invoke("firstSec",1);
    Invoke("TeleToWizard",5f);
}

void TeleToWizard() {
    //this maves the position of the wizard the same as the enemy
    transform.position = GameObject.FindWithTag("Player").transform.position; 

    //For the first 1 second 
    //Transparent - The 1st 1 minute the image is transparent 
    GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
    invincible = true;
    Invoke("firstSec",1f);
    //After 5 seconds, the function is played again
    Invoke("TeleToWizard",5f);
}

void firstSec(){
    //turns the transparency back to full
    GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        invincible = false;
    //Prticles??
    transform.GetComponent<ParticleSystem>().Play();

    //calculate the distance between the enemy and the wizard
    hitDistance =  Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
    
    if (transform.GetChild(0).GetComponent<Enemy5Detector>().WizardInDangerZone)
        {
            Debug.Log("HIT DISTANCE: " + hitDistance);
            GameObject.FindWithTag("Player").GetComponent<Wizard>().KnockBack(transform, hitDistance);
            Wizard.damageDealt(1);
        }
  
    //GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,hitDistance);
}

    private void Update() {
        
        transform.position = new Vector3(transform.position.x, transform.position.y  + Mathf.PingPong(Time.time*speed,distance)-0.5f*distance,0);
        if (invincible)
        {
            tag = "Untagged";
            gameObject.layer = 0;
        }
        else
        {
            tag = "Enemy";
            gameObject.layer = 13;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            //Wizard.damageDealt(1);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled", 0) + 1);
        GameObject EneKilledUIText = GameObject.Find("EnemiesKilledUIText");
        int enKilledInt = int.Parse(EneKilledUIText.GetComponent<TextMeshProUGUI>().text);
        enKilledInt++;
        EneKilledUIText.GetComponent<TextMeshProUGUI>().text = enKilledInt.ToString();
    }
}

