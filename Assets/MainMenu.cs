using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // thư viện có chức năng load được các scene

public class MainMenu : MonoBehaviour
{
    public void PLayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Khi nhấn vào sẽ load scene village
    }
    public void QuitGame()
    {
        //Debug.Log("Quit!!!");
        Application.Quit();
    }

}
