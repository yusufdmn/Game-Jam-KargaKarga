using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public float x;
    public float y;

    public UnityEvent OnMouseClick;


    void Update()
    {       
        if(Input.GetMouseButtonDown(0)){
            OnMouseClick.Invoke();
        }
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");        
    }

}