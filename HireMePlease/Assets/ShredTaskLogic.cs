using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredTaskLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstPaper;
    public GameObject Spawner;
    public int shreddedPieces;

    private void OnEnable() {
        shreddedPieces = 0;
        Instantiate(firstPaper,
                    Random.insideUnitSphere * 50 + this.transform.position, 
                    Quaternion.identity).transform.SetParent(this.transform);
        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion(){
        while(shreddedPieces < 4){
            Debug.Log("Not Finished Shred Task");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("SHRED TASK COMPLETE");
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
