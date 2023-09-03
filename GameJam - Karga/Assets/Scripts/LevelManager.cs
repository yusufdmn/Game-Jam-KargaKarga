using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
 #region Singleton Definiton
    private static LevelManager instance;       // ******Definition of Singleton********


    public static LevelManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject failPanel;


    [SerializeField] GameObject pausePanel;
    public void FinishLevel(){
        successPanel.SetActive(true);
    }
    public void LevelFailed(){
        failPanel.SetActive(true);
    }
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.P)){
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackTomenu(){
        SceneManager.LoadScene(0);
    }
}
