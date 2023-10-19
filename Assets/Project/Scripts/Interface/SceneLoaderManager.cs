using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    private void Start() {
        SceneEventController.GetCurrent.onLoadWinScene += LoadWinScene;
        SceneEventController.GetCurrent.onLoadLooseScene += LoadLooseScene;
        Debug.Log("SceneLoader");
    }
    public void LoadSceneById(int idScene){
        // SceneManager.LoadScene(idScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void LoadWinScene(){
        SceneManager.LoadScene("WinLevel");
    }
    public void RestarActualScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLooseScene(){
        // SceneManager.LoadScene("LevelOver");
    }
}
