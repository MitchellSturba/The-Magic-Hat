using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpawnPoint : MonoBehaviour
{
    public GameObject FirstSpawnPoint;
    public GameObject[] Procedurals;
    public GameObject[] PlatformPrefabs;
    // Start is called before the first frame update
    void Awake()
    {
        //GameObject y = Instantiate<GameObject>(Procedurals[Random.Range(0,3)]);
        //y.transform.SetParent(transform);

        //Vector3 tmp = FirstSpawnPoint.transform.position;
        //tmp.x += 60;
        //transform.position = tmp;     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

            GameObject[] PlatformLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach (GameObject zx in PlatformLocations)
            {
                zx.tag = "Untagged";
            }
            FirstSpawnPoint.transform.position = transform.position;

            Vector3 tmp = FirstSpawnPoint.transform.position;
            tmp.x += 30;
            FirstSpawnPoint.transform.position = tmp;

            GameObject y = Instantiate<GameObject>(Procedurals[Random.Range(0, Procedurals.Length)]);
            y.transform.position = FirstSpawnPoint.transform.position;
            y.transform.SetParent(FirstSpawnPoint.transform);

            Destroy(FirstSpawnPoint.transform.GetChild(0).gameObject);
            //GameObject[] Espawns = GameObject.FindGameObjectsWithTag("ESpawnPoint");
            //GameObject randS = Espawns[Random.Range(0,Espawns.Length - 1)];
            //Instantiate<GameObject>(enemiesToSpawn[0],randS.transform);
            //randS.tag = "Untagged";

            FirstSpawnPoint.GetComponent<BoxCollider2D>().enabled = true;

            PlatformLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
            //Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[Random.Range(0, PlatformLocations.Length)].transform);
            int numPlatformsToSpawn = Random.Range(1, 3);
            if (numPlatformsToSpawn == 1)
            {
                Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[Random.Range(0, PlatformLocations.Length)].transform);
            }
            if (numPlatformsToSpawn == 2)
            {
                Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[0].transform);
                Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[1].transform);
            }
            //Transform sp1;
            //if (Random.Range(0, 1) == 0)2
            //{
            //    sp1 = y.transform.Find("SP1");
            //}
            //else
            //{
            //    sp1 = y.transform.Find("SP2");
            //}
            //GameObject asdf = Instantiate<GameObject>(enemiesToSpawn[0], GameObject.Find("SP1").transform);
        }
    }

}
