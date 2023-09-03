using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{


    [SerializeField] GameObject[] pictures;
    void Start()
    {
        StartCoroutine("Slide");

    }


    void Update()
    {
        
    }


    public IEnumerator Slide(){
        pictures[0].SetActive(true);
        yield return new WaitForSeconds(3);
        pictures[0].SetActive(false);
        pictures[1].SetActive(true);
        yield return new WaitForSeconds(3);
        pictures[2].SetActive(true);
        pictures[1].SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);

    }
}
