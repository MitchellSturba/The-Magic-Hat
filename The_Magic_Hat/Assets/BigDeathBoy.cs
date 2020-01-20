using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDeathBoy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wizard.damageDealt(1000);
    }

}
