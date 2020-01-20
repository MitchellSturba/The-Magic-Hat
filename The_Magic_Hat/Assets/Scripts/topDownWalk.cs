using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownWalk : MonoBehaviour
{
    [SerializeField]
    private float walkspeed = 10f;
    private float moveInputx;
    private float moveInputy;

    private Animator anim;
    private Rigidbody2D rb;

    private bool faceright = true;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputx = Input.GetAxis("Horizontal");
        moveInputy = Input.GetAxis("Vertical");

        if (moveInputx > 0)
        {
            anim.SetBool("Walking",true);
            if (!faceright) flip();
        }else if (moveInputx < 0)
        {
            anim.SetBool("Walking",true);
            if (faceright) flip();
        }
        else
        {
            anim.SetBool("Walking",false);
        }

        transform.Translate(Vector2.right * moveInputx * walkspeed);
        transform.Translate(Vector2.up * moveInputy * walkspeed);
    }

    private void flip()
    {
        faceright = !faceright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
