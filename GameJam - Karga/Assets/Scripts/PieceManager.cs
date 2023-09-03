using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PieceManager : MonoBehaviour
{

    GameObject player;

  //  public UnityEvent OnCollected;
    public int collectedCount;
    public int maxCollectedCount_Level_1;
    public int maxCollectedCount_Level_2;
    [SerializeField] InputManager inputManager;
    [SerializeField] float maxCollectDistance;

    void Start()
    {
        inputManager.OnMouseClick.AddListener(DetectCollection);
        player = GameObject.FindGameObjectWithTag("player");
    }


    void Update()
    {
        
    }

    public void CollectPiece(GameObject piece){
        CollectablePiece collectablePiece = piece.GetComponent<CollectablePiece>();

        float distanceToPiece = (player.transform.position - piece.transform.position).magnitude;
        if(distanceToPiece > maxCollectDistance){ 
            return;
        }

        collectablePiece.Collect();
        collectedCount++;

        if(collectedCount >= maxCollectedCount_Level_2){
           // Finish The Game
        }
        else if(collectedCount >= maxCollectedCount_Level_1){
            // Finish The Level
        }
    }

    private void DetectCollection(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("piece"))
            {
                CollectPiece(hit.collider.gameObject);
            }
        }
    }    
}

