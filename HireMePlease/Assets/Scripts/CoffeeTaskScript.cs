using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsTaskCompleted = false;
    //public GameObject currentPlayer;
    
    private void OnEnable(){
        IsTaskCompleted = false;
        StartCoroutine(CheckTaskCompletion());
    }
    private IEnumerator CheckTaskCompletion(){
        
        while(!IsTaskCompleted){
            if(!IsTaskCompleted){
                //Debug.Log("COFFE TASK INCOMPLETE");
            }
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("COFFE TASK IS NOW COMPLETE");
        //GetComponent<GetPlayer>().player.GetComponent<Player>().taskComplete();

        Player currPlayer = GetComponent<GetPlayer>().player.GetComponent<Player>();
        currPlayer.taskComplete();
        
        if(currPlayer.taskDone % 3 == 0){
            currPlayer.generateThreeTasks();
        }

        yield return new WaitForSeconds(3f);
        //THIS IS WHERE WE GIVE POINTS
        Debug.Log(gameObject.GetComponent<GetPlayer>().player);
        gameObject.SetActive(false);
    }
}
