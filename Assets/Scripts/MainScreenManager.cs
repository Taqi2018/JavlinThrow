using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    public GameObject splashMenu;
    public GameObject Menu;
    public GameObject Instruction;
    public GameObject Loading;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SplashScreen()
    {
        splashMenu.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        splashMenu.SetActive(false);
        Menu.SetActive(true);
    }
    public void GamePlay()
    {
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        Loading.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GamePlay");

    }
  /*  public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }*/

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }



    public void QuitGame()
    {
        Application.Quit();
    }


}
