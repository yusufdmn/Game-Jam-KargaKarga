using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform followedPlayer;
    public float smoothDamp = 0.15f;
    public Vector3 offset;
    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPos = followedPlayer.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothDamp);

    }

}