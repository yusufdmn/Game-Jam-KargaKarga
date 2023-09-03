using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void GoToNextLevel(){
        SceneManager.LoadScene(2);
    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }
}