using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private GameObject _taskWindow;

    public void Use(bool isActive, GameObject player)
    {
        if (player == null)
        {
            _taskWindow.SetActive(isActive);
            return;
        }

        Player playerInstance = player.GetComponent<Player>();
        if (playerInstance == null) { return; }

        if (playerInstance.TaskList[playerInstance.taskDone].taskID == 0 && _taskWindow.name == "CoffeeTask")
        {
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
        }
        else if (playerInstance.TaskList[playerInstance.taskDone].taskID == 1 && _taskWindow.name == "TrashTask")
        {
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
        }
        else if (playerInstance.TaskList[playerInstance.taskDone].taskID == 2 && _taskWindow.name == "PresentationTask")
        {
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
        } else if (playerInstance.TaskList[playerInstance.taskDone].taskID == 3 && _taskWindow.name == "ShredPaperTask")
        {
            Debug.Log("Test");
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
                                    Debug.Log("lmaooo");

        } else if (playerInstance.TaskList[playerInstance.taskDone].taskID == 4 && _taskWindow.name == "SpamTask")
        {
                        Debug.Log("Test2");
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
                                                Debug.Log("lmaooo22222");

        }
    }
}
