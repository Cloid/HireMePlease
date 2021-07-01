using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerTracker : MonoBehaviour
{
   // Camera mCamera;
    private Transform t;
    public GameObject Obj;
    public Sprite[] SpriteArray;
    private void OnGUI() {
        var gotransform = Obj.GetComponent<Transform>();
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3 (0, 0, 0);
        //rt.position = Camera.main.WorldToScreenPoint(gotransform.position);
    }
}
