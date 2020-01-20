using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject PauseScreen;
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UnPauseGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Respawn() {
        FirstSpawnPoint.spawnCount = 0;
        Wizard.collectables = 0;
        Wizard.hearts = 6;
        Wizard.numFireballs = 0;
        Wizard.numTeleports = 0;
        Wizard.laserEyeTimeLeft = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

}
