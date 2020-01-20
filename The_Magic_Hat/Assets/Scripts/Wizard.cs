using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class Wizard : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D myRig;
    public float walkspeed;
    public float jumpspeed;
    public GameObject fireball;
    private int jumps = 2;

    private bool rightface = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public GameObject GOver;
    private float moveInputx;

    public static int hearts, numTeleports = 0, numFireballs = 0, collectables;
    public GameObject FirstHeartAncor;
    public Sprite HeartImage;
    public TextMeshProUGUI collectablesText;
    bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        collectables = PlayerPrefs.GetInt("Collectables",0);
        GameObject.Find("NumCollects").GetComponent<TextMeshProUGUI>().text = collectables.ToString();

        hearts = 6;
        laserEyes = false;
        laserEyeTimeLeft = 0;
        anim = gameObject.GetComponent<Animator>();
        myRig = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(transform.GetChild(1).name);
    }

    public static bool laserEyes = false;

    //laser eyes
    void LaserEyes()
    {
            transform.GetComponent<LineRenderer>().enabled = true;
            Vector3 tmp = GameObject.FindWithTag("Player").transform.position;
            transform.GetComponent<LineRenderer>().SetPosition(0, tmp);

            Vector3 tmpz = Input.mousePosition;
            tmpz.z = 10;

        Vector3 asdf = Camera.main.ScreenToWorldPoint(tmpz);

        transform.GetComponent<LineRenderer>().SetPosition(1, asdf);

        if (Input.GetKey(KeyCode.Mouse0)) {
            Vector3 laserEyeOrigin = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            Vector3 rererere = asdf - transform.position;
            Debug.DrawRay(transform.position, rererere, Color.green);
            RaycastHit2D rayhit2d = Physics2D.Raycast(transform.position, rererere, Vector3.Distance(transform.position,rererere) + 1.4f, 1 << LayerMask.NameToLayer("Enemy"));
            if (rayhit2d)
            {
                Debug.Log("RAYHIT " + rayhit2d.transform.tag);
                if (rayhit2d.transform.tag.Equals("Enemy"))
                {
                    Destroy(rayhit2d.transform.gameObject);
                }
            }
        }

    }

    public static int laserEyeTimeLeft = 0;
    public static bool oneOFF = false;
    void LaserEyeTimer()
    {
        laserEyeTimeLeft--;
        if (laserEyeTimeLeft >= 0)
        {
            Invoke("LaserEyeTimer", 1f);
            GameObject.Find("LaserTimeText").GetComponent<TextMeshProUGUI>().text = "Laser Time: " + laserEyeTimeLeft;

        }
        else{
            laserEyes = false;
            
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        } 

    }

    //teleports the wizard.
    void WizTeleport()
    {
        Debug.Log("I DETECT A TELEPORT");
        if (numTeleports > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.3773585f,0.3773585f,0.3773585f,0.5f);
            invincible = true;
            Vector3 tmpz = Input.mousePosition;
            tmpz.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(tmpz);
            //Debug.DrawRay(transform.position,Input.mousePosition);
            numTeleports--;
            GameObject.Find("TeleportText").GetComponent<TextMeshProUGUI>().text = numTeleports.ToString();
            Vector3 tmp = transform.position;
            tmp.z = 0;
            transform.position = tmp;
            jumps = 2;
            Invoke("invins",2);
        }
        else if(numTeleports == 0){
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        }
    }

    public void invins(){

        Debug.Log("I AM NO MORE INVINCIBLE");
            invincible = false;
            GetComponent<SpriteRenderer>().color = new Color(0.3773585f,0.3773585f,0.3773585f,1f);
            
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (laserEyes)
        {
            if (oneOFF)
            {
                laserEyeTimeLeft = 30;
                LaserEyeTimer();
                oneOFF = false;
            }
            LaserEyes();
        }
        moveInputx = Input.GetAxis("Horizontal");
        if (running) transform.Translate(Vector2.right * moveInputx * walkspeed * 1.4f);
        else transform.Translate((Vector2.right * moveInputx * walkspeed));

        if (moveInputx > 0)
        {
            if (!rightface) flip();
            anim.SetBool("Walking",true);
        }else if (moveInputx < 0)
        {
            if (rightface) flip();
            anim.SetBool("Walking", true);
        }
        if (moveInputx == 0) anim.SetBool("Walking",false);
        if (myRig.velocity.y <= -0.1)
        {
            anim.SetBool("Jumping", true);
        }

    }
    private bool running = false;


    private void Update()
    {
        //This is to make the wizard invincible after teleportation

         if (invincible)
        {
            //tag = "Untagged";
            //gameObject.layer = 0;
        }
        else
        {
            tag = "Player";
            gameObject.layer = 9;
        }

        if (hearts <= 0) killWizard();

        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            anim.SetTrigger("Cast");
            Invoke("castFireball", .05f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            jumps--;
            myRig.velocity = new Vector2(myRig.velocity.x, jumpspeed);
            anim.SetBool("Jumping", true);
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !laserEyes)
        {
            WizTeleport();
        }

        //cast fireball
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (numFireballs > 0)
            {
                CastFireBall();
            }
        }

        //laser eyes
        if (laserEyes && Input.GetKey(KeyCode.Mouse0))
        {
            transform.GetComponent<LineRenderer>().enabled = true;
            Vector3 tmp = GameObject.FindWithTag("Player").transform.position;
            transform.GetComponent<LineRenderer>().SetPosition(0, tmp);

            Vector3 tmpz = Input.mousePosition;
            tmpz.z = 10;

            Vector3 asdf = Camera.main.ScreenToWorldPoint(tmpz);
            transform.GetComponent<LineRenderer>().SetPosition(1, asdf);
        }
        else
        {
            transform.GetComponent<LineRenderer>().enabled = false;
        }

        //cam follow
        Vector3 camPos= GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().transform.position;
        Vector2 wizposinport = Camera.main.WorldToViewportPoint(this.transform.position);
        if (wizposinport.x < 0)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }

    public GameObject Fireball;
    public void CastFireBall()
    {
        numFireballs--;
        GameObject fireBz = Instantiate<GameObject>(Fireball, transform.GetChild(0).transform);
        if (transform.localScale.x < 0)
        {
            Debug.Log("FACING LEFT BRO");
            fireBz.GetComponent<SpriteRenderer>().flipX = true;
        }
        GameObject.Find("FireballText").GetComponent<TextMeshProUGUI>().text = numFireballs.ToString();
        fireBz.transform.parent = null;
        if(numFireballs == 0){
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        }
    }

    public void KnockBack(Transform enemyPos)
    {
        if (enemyPos.position.x > transform.position.x)
        {
            myRig.AddForce(Vector2.left * 500);
            myRig.AddForce(Vector2.up * 400);
       }
        else
        {
            myRig.AddForce(Vector2.right * 500);
            myRig.AddForce(Vector2.up * 400);
        }
    }

    public void KnockBack(Transform enemyPos, float hitDistance)
    {
        if (enemyPos.position.x > transform.position.x)
        {
            myRig.AddForce(Vector2.left * 800 / hitDistance/1.2f);
            myRig.AddForce(Vector2.up  * 700 / hitDistance/ 1.2f);
       }
        else
        {
            myRig.AddForce(Vector2.right * 800 / hitDistance/ 1.2f);
            myRig.AddForce(Vector2.up * 700 / hitDistance/ 1.2f);
        }
    }

    public void flip()
    {

        rightface = !rightface;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;

    }

    public static void healWizard(int healpoints)
    {
        hearts += healpoints;

        for (int j = 1; j <= hearts; j++)
        {
            GameObject.Find("Heart" + j).GetComponent<Image>().enabled = true;
        }
    }

    public static void damageDealt(int hitPoints)
    {
            int i = hearts;
            hearts -= hitPoints;
            for (; i > hearts; i--)
            {
                GameObject.Find("Heart" + i).GetComponent<Image>().enabled = false;
            }
       
    }

    public GameObject DeathScreen;
    public void killWizard()
    {
        DeathScreen.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLIDE WITH " + collision.transform.name);
        if (collision.collider.transform.name.Equals("Enemy_Head")) {
            Destroy(collision.collider.transform.parent.gameObject);
            GameObject EneKilledUIText = GameObject.Find("EnemiesKilledUIText");
            int enKilledInt = int.Parse(EneKilledUIText.GetComponent<TextMeshProUGUI>().text);
            enKilledInt++;
            EneKilledUIText.GetComponent<TextMeshProUGUI>().text = enKilledInt.ToString();
            PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled", 0) + 1);
        }
        if (collision.collider.transform.name.Equals("Trapdoor"))
        {
            Destroy(collision.collider.transform.gameObject);
        }
        if (collision.collider.transform.name.Equals("Lava"))
        {
            Destroy(gameObject);
            GOver.SetActive(true);
        }

        if (collision.transform.name.Equals("Tilemap") && myRig.velocity.y <= 0)
        {
            jumps = 2;
            anim.SetBool("Jumping",false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name.Equals("Tilemap") && myRig.velocity.y <= 0)
        {
            jumps = 2;
            anim.SetBool("Jumping", false);
        }
    }

    public static void AddCollectiable(int n)
    {
        collectables += n;
        GameObject.Find("NumCollects").GetComponent<TextMeshProUGUI>().text = collectables.ToString();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("PARTICLE HIT");
        KnockBack(other.transform);
        damageDealt(1);
        //Destroy(other.gameObject);
    }

    public void changeColour(float r, float g, float b, float t){
        Color c = new Color(r,g,b,t);
        GetComponent<SpriteRenderer>().color = c;
        
    }

    public void changeColour(float r, float g, float b, float t, float amountOfTimeWizardIsColorFor)
    {
        Color c = new Color(r,g,b,t);
        GetComponent<SpriteRenderer>().color = c;
        Invoke("changeColorBackToNormal",amountOfTimeWizardIsColorFor);
    }

    public void changeColorBackToNormal() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
}
