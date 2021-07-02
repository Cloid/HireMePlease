using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPieceScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("ENTERED TRIGGER");
        if(other.CompareTag("Shredder")){
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<ShredMachineScript>().currentPaper = this.gameObject;

            //Destroy(this.GetComponent<DragTarget>());
            this.GetComponent<DragTarget>().forceStopDrag();

            //Destroy(this.GetComponent<TargetJoint2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
            //this.GetComponent<Rigidbody2D>().isKinematic = true;

            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.position = other.transform.position + new Vector3(0, 150, 0);
            this.GetComponent<RectTransform>().rotation = Quaternion.EulerAngles(0f, 0f, 0f);
        }
    }

    private void OnDisable() {
        Destroy(this.gameObject);
    }

    private void OnDestroy() {
        if(transform.parent.GetComponent<ShredMachineScript>() != null){
            Debug.Log("Shredding Paper");
            transform.parent.GetComponent<ShredMachineScript>().shreddedPaper();
        }
        else{
            Debug.Log("Shredding Paper");
        }
        transform.parent.GetComponent<BoxCollider2D>().enabled = true;
    }
}
