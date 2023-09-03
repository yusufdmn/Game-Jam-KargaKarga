using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
 
public class PieceManager : MonoBehaviour
{
    private GameObject player;

    [SerializeField] RectTransform gameCanvasRect;
    [SerializeField] RectTransform panelRect;
    [SerializeField] InputManager inputManager;
    [SerializeField] float maxCollectDistance;
    [SerializeField] Ease ease;
    [SerializeField] float animationDuration;

    public int collectedCount;
    public int maxCollectedCount_Level_1;
    public int maxCollectedCount_Level_2;


    void Start()
    {
        inputManager.OnMouseClick.AddListener(DetectCollection);
        player = GameObject.FindGameObjectWithTag("player");
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
            SceneManager.LoadScene(2);
        }
    }

    private void DetectCollection(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("piece"))
            {
                Vector2 canvasPosition;
                Vector2 mousePos = Input.mousePosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(gameCanvasRect, mousePosition, null, out canvasPosition);


                Debug.Log(canvasPosition);
                CollectPiece(hit.collider.gameObject);
            }
        }
    }    
}

