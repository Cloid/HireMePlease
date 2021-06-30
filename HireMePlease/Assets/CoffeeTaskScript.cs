using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsTaskCompleted = false;
    private void OnEnable(){
        StartCoroutine(CheckTaskCompletion());
    }
    private IEnumerator CheckTaskCompletion(){
        
        while(!IsTaskCompleted){
            if(!IsTaskCompleted){
                Debug.Log("TASK INCOMPLETE");
            }
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("TASK COMPLETE");
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
