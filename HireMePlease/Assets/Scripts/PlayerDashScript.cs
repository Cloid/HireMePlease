using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashScript : MonoBehaviour
{
    public float dashDist = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // do dash
    void DoDash(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            //transform.position += lastMoveDir * dashDist;
        }
    }

    private bool MoveCheck(Vector3 dir, float dist) {
        return Physics2D.Raycast(transform.position, dir, dist).collider == null;
    }
}
