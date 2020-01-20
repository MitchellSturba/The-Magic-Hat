using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_plat_move : MonoBehaviour
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
       transform.position = new Vector2(transform.position.x, startPosition.y  + Mathf.Sin(Time.time * speed));
    }
}
