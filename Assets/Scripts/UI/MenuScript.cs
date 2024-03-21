using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ChangeScene(string destination)
    {
        if(Time.timeScale > 0) {
            SceneManager.LoadScene(destination);
        }
    }

    public void Quit()
    {
        if(Time.timeScale > 0) {
            Application.Quit();
        }
    }
}