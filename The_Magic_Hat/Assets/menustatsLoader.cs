using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menustatsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            transform.GetComponent<TextMeshPro>().text = "Collectables: " + PlayerPrefs.GetInt("Collectables", 0) + "\n\n" +
        	"Enemies: " + PlayerPrefs.GetInt("EnemiesKilled", 0);        
    }

}
