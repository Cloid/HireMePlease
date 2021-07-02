using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredMachineScript : MonoBehaviour
{
    public GameObject currentPaper;
    public int shreddedPapers = 0;

    private void OnEnable() {
        shreddedPapers = 0;
    }

    public void shreddedPaper(){
        transform.parent.GetComponent<ShredTaskLogic>().shreddedPieces++;
        shreddedPapers = transform.parent.GetComponent<ShredTaskLogic>().shreddedPieces;
    }
    
}
