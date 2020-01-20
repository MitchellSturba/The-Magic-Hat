using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRotate : MonoBehaviour
{
    float starty;
    public bool rotate = false;

        private void Start()
    {
        starty = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (rotate) transform.Rotate(0,0, 80 * Time.deltaTime);
        Vector3 tmp = transform.position;
        tmp.y =starty + Mathf.PingPong(Time.time/2,.5f);
        transform.position = tmp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (Wizard.hearts<6) {Wizard.healWizard(1);
        GameObject.FindWithTag("Player").GetComponent<Wizard>().changeColour(1f,.5f,.5f,1f,1f);
        }  
    }

}
