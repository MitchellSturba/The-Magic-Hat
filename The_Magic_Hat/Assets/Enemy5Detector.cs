using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Detector : MonoBehaviour
{
    public bool WizardInDangerZone = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WizardInDangerZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        WizardInDangerZone = false;
    }

    private void OnDestroy()
    {
        WizardInDangerZone = false;
    }
}
