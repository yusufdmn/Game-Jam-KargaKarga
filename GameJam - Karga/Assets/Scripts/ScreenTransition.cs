using System.Collections;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Animator animator;
    
    void Start()
    {
        panel.SetActive(false);     
    }


    public void StartTransitionCoroutine(){
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition(){
        panel.SetActive(true);
        animator.SetTrigger("transit");
        yield return new WaitForSeconds(1.45f);
        panel.SetActive(false);
    }
}
