using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    bool started = false;
    public GameObject[] thingsToHide;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !started && xpos == 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("GameStartAnim");
            started = true;
            Invoke("LoadJungle",29.5f);
            foreach (GameObject x in thingsToHide)
            {
                x.SetActive(false);
            }
        }

        if (goLeftx && Camera.main.transform.position.x > xpos)
        {
            Vector3 tmp = Camera.main.transform.position;
            tmp.x -= 8 * Time.deltaTime;
            Camera.main.transform.position = tmp;
            if (Camera.main.transform.position.x <= xpos)
            {
                tmp.x = xpos;
                Camera.main.transform.position = tmp;
                goLeftx = false;
            }
        }
        if (goRightx && Camera.main.transform.position.x < xpos)
        {
            Vector3 tmp = Camera.main.transform.position;
            tmp.x += 8 * Time.deltaTime;
            Camera.main.transform.position = tmp;
            if (Camera.main.transform.position.x >= xpos)
            {
                tmp.x = xpos;
                Camera.main.transform.position = tmp;
                goRightx = false;
            }
        }

    }

    bool goLeftx = false, goRightx = false;
    int xpos = 0;
    public void goLeft()
    {
        if (xpos > 0)
        {
            goLeftx = true;
            xpos -= 3;
            thingsToHide[1].SetActive(true);
            if (xpos == 0) thingsToHide[1].SetActive(false);
            if (xpos < 15) thingsToHide[0].SetActive(true);
        }
    }
    public void goRight()
    {
        if (xpos < 15)
        {
            goRightx = true;
            xpos += 3;
            thingsToHide[0].SetActive(true);
            if (xpos == 15) thingsToHide[0].SetActive(false);
            if (xpos > 0) thingsToHide[1].SetActive(true);
        }
    }

    void LoadJungle()
    {
        SceneManager.LoadScene(1);
    }
}
