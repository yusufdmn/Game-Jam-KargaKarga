using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject failPanel;

    public void FinishLevel(){
        successPanel.SetActive(true);
    }
    public void LevelFailed(){
        failPanel.SetActive(true);
    }
}
