using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    private void Start() {
        SceneEventController.GetCurrent.onLoadWinScene += LoadWinScene;
        SceneEventController.GetCurrent.onLoadLooseScene += LoadLooseScene;
    }
    public void LoadSceneById(int idScene){
        SceneManager.LoadScene(idScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void LoadWinScene(){
        Debug.Log("winnnnnn");
        LoadSceneById(3);
        // SceneManager.LoadScene("WinLevel1");
    }
    public void RestarActualScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLooseScene(){
        SceneManager.LoadScene("LevelOver");
    }
}
