using UnityEngine;


public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;
    
    // V2
    private Vector3 velocity = Vector3.zero;
    
    private void LateUpdate()
    {
        // V1
        var desiredPosition = player.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
        
        // V2
        //var targetPosition = player.position + offset;
        //var dampedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        //transform.position = new Vector3(dampedPosition.x, transform.position.y, transform.position.z);
        
        //transform.LookAt(player);
        
        // V3 Basic
        //Vector2 targetPosition = player.position + offset;
        //transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
    }
}

