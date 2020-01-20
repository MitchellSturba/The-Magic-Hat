using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Wizard.laserEyes && Input.GetKey(KeyCode.Mouse0))
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
    }
}
