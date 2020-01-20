using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

Vector3 tmp;

private void Start() {
    Vector3 tmp = transform.position;
}

    // Update is called once per frame
    void Update()
    {
    
        transform.position = new Vector3(tmp.x,Mathf.PingPong(Time.time+1,4) + tmp.y);
    }
}
 