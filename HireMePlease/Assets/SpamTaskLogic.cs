using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamTaskLogic : MonoBehaviour
{   

    public GameObject PopUp;
    public int tasks;


    // Start is called before the first frame update
    private void OnEnable() {
        for(int i = 0; i <= 8; i++){
            //Debug.Log("SPAWN: " + i);
            //float angle = i * Mathf.PI*2f / 4;
            //Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, 1, Mathf.Sin(angle)*radius);
            //var position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(PopUp,
                        Random.insideUnitSphere * 150 + this.transform.position, 
                        Quaternion.identity).transform.SetParent(this.transform);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion(){
        while(this.transform.childCount > 0){
            Debug.Log("Not Finished PopUp Task");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("POP UP TASK COMPLETE");
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
