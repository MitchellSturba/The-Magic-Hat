using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonHead : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            transform.parent.GetComponent<SkeletonScript>().Die();
            transform.parent.GetComponent<SkeletonScript>().GetComponent<Animator>().Play("Dead");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            transform.parent.GetComponent<SkeletonScript>().Die();
            transform.parent.GetComponent<SkeletonScript>().GetComponent<Animator>().Play("Dead");
        }
    }
}
