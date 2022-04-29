using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 disirePosition = target.position + offset;
        
        transform.position = disirePosition;
    }
}
