using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CollectablePiece : MonoBehaviour
{
    [SerializeField] private GameObject pieceImage;

    public void Collect(){
        pieceImage.SetActive(true);
        Destroy(this.gameObject);
    }

}