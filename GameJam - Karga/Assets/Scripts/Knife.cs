using UnityEngine;

public class Knife : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("enemy")){
            other.gameObject.transform.parent.GetComponent<Enemy>().Die();
        }
    }
}
