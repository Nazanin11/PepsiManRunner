using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Player reference
    public Vector3 offset;     // Camera offset relative to player
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        // Smooth follow player movement
        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
