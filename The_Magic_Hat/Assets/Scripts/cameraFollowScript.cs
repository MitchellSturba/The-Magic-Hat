using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{

    public GameObject Wizard;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tmp = transform.position;
        if (Wizard.transform.position.x > tmp.x) tmp.x = Wizard.transform.position.x;
        tmp.y = Wizard.transform.position.y;
        transform.position = tmp;
    }
}
