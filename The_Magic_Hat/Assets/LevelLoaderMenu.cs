using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderMenu : MonoBehaviour
{
    public int SceneToLoad;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
