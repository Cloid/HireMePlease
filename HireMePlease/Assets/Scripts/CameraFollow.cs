using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
    }
    void FixedUpdate()
    {
        if(target == null){return;}
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, 10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
    }
}
