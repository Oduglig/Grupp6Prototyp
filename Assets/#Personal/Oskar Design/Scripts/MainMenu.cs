using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [FMODUnity.ParamRef] 
    public string paramRef;

    public float paramValue;
    public bool ignoreSeek = false;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //load whatever scene you want to go to. Either Name or Index
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //or next scene in list
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(paramRef, paramValue, ignoreSeek);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public GameObject BackButton;
    void start()
    {
        BackButton.SetActive(false);

    }


}
