using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandObjectSpawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("I HAVE AWOKEN");
        Instantiate<GameObject>(ObjectsToSpawn[Random.Range(0,ObjectsToSpawn.Length)],this.transform);
        transform.parent = transform;
    }

}
