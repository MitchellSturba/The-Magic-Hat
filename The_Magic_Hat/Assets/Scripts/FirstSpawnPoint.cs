using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawnPoint : MonoBehaviour
{
    public GameObject[] Procedurals;
    public GameObject SecondSpawnPoint;
    public static int spawnCount = 0;
    public GameObject[] PlatformPrefabs;
    public int numProcedesToGenerate;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject x = Instantiate<GameObject>(Procedurals[Random.Range(0, Procedurals.Length - 1)]);
        x.transform.SetParent(this.transform); 
        x.transform.position = transform.position;

        //Vector3 tmp = transform.position;
        //tmp.x += 216;
        //tmp.y -= 35;
        //transform.position = tmp;
    }

    private void Start()
    {
        spawnCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SPAWNCOUNT " + spawnCount);
        if (spawnCount < numProcedesToGenerate/2)
        {
            if (collision.tag.Equals("Player"))
            {
                this.GetComponent<BoxCollider2D>().enabled = false;

                GameObject[] PlatformLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
                foreach (GameObject zx in PlatformLocations)
                {
                    zx.tag = "Untagged";
                }

                SecondSpawnPoint.transform.position = transform.position;

                Vector3 tmp = SecondSpawnPoint.transform.position;
                tmp.x += 30;
                SecondSpawnPoint.transform.position = tmp;

                GameObject y = Instantiate<GameObject>(Procedurals[Random.Range(0, Procedurals.Length)]);
                y.transform.position = SecondSpawnPoint.transform.position;
                y.transform.SetParent(SecondSpawnPoint.transform);

                if (spawnCount > 0) Destroy(SecondSpawnPoint.transform.GetChild(0).gameObject);

                spawnCount++;

                //GameObject[] Espawns = GameObject.FindGameObjectsWithTag("ESpawnPoint");
                //GameObject randS = Espawns[Random.Range(0, Espawns.Length - 1)];
                //Instantiate<GameObject>(enemiesToSpawn[0], randS.transform);
                //randS.tag = "Untagged";

                SecondSpawnPoint.GetComponent<BoxCollider2D>().enabled = true;

                PlatformLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
                int numPlatformsToSpawn = Random.Range(1,3);
                if (numPlatformsToSpawn == 1)
                {
                    Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[Random.Range(0, PlatformLocations.Length)].transform);
                }
                if (numPlatformsToSpawn == 2)
                {
                    if (PlatformLocations.Length >= 2)
                    {
                        Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[0].transform);
                        Instantiate<GameObject>(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)], PlatformLocations[1].transform);
                    }
                }

                //Transform sp1;
                //if (Random.Range(0, 1) == 0)
                //{
                //    sp1 = y.transform.Find("SP1");
                //}
                //else
                //{
                //    sp1 = y.transform.Find("SP2");
                //}
                //GameObject asdf =  Instantiate<GameObject>(enemiesToSpawn[0],GameObject.Find("SP1").transform);
                //asdf.transform.position = sp1.transform.position;
            }
        }
    }

}
