using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
  

  public void PlayGame()
   {
        SceneManager.LoadScene("GamePlay");
   }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }



    public void QuitGame()
    {
        Application.Quit();
    }


}


