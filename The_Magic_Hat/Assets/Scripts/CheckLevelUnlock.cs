using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelUnlock : MonoBehaviour
{
    public int levelCheck;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level" + levelCheck + "Unlocked",0) == 1) gameObject.SetActive(false);   
    }
}
