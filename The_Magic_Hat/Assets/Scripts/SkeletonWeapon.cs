using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWeapon : MonoBehaviour
{
    public static bool WizardHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT TRUE");
        WizardHit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("HIT FALSE");
        WizardHit = false;
    }

}
