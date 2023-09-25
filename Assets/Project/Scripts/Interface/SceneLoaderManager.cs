using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public void LoadSceneById(int idScene){
        SceneManager.LoadScene(idScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void LoadWinScene(){
        SceneManager.LoadScene("WinLevel");
    }
}
