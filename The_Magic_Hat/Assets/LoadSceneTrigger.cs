using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public int levelToUnlock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SceneManager.LoadScene(levelToUnlock + 1);
            PlayerPrefs.SetInt("Level" + levelToUnlock + "Unlocked", 1);
        }
    }

    

}
