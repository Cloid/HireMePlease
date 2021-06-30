using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskGiver : MonoBehaviour
{

    public Task task;
    public Player player;

    public GameObject taskWindow;
    public Text titleText;
    public Text descText;
    

    public void OpenTaskWindow(){
        taskWindow.SetActive(true);
    }
}
