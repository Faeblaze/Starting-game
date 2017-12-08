using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTest : MonoBehaviour
{

	void Update ()
        // i put in Escape BUT STILL IS SPACE to get to mainmenu
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MENU SCENE", LoadSceneMode.Single);
        }
    }
}
