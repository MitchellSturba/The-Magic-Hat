using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_animation : MonoBehaviour
{
    private Vector2 startPosition; 
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector2(startPosition.x + Mathf.Sin(Time.time * speed), transform.position.y);
    }
}
