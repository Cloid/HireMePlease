using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationTaskLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int correctSlides = 0;
    private void OnEnable() {
        correctSlides = 0;
        StartCoroutine(CheckTaskCompletion());
    }

    // Update is called once per frame
    private IEnumerator CheckTaskCompletion(){
        while(correctSlides != 4){
            Debug.Log("Not Completed the Presentation Task...." + correctSlides);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("PRESENTATION TASK COMPLETE");
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
