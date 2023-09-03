using UnityEngine;

public class CollectablePiece : MonoBehaviour
{
    [SerializeField] private GameObject pieceImage;

    public void Collect(){
        pieceImage.SetActive(true);
        Destroy(this.gameObject);
    }

}