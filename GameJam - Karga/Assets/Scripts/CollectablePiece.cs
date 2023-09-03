using UnityEngine;

public class CollectablePiece : MonoBehaviour
{
    [SerializeField] private GameObject pieceImage;

    public void Collect(){
        AudioManager.Instance.PlayCollectPiece();
        pieceImage.SetActive(true);
        Destroy(this.gameObject);
    }

}