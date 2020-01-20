using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{

    float starty;
    bool floating = true;

    private void Start()
    {
        starty = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (floating)
        {
            Vector3 tmp = transform.position;
            tmp.y = starty + Mathf.PingPong(Time.time / 2, .5f);
            transform.position = tmp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        floating = false;
        transform.parent = GameObject.Find("HatLocation").transform;
        transform.localPosition = new Vector3(0,0,0);
        transform.GetComponent<SpriteRenderer>().sortingOrder = 444;
    }

}
