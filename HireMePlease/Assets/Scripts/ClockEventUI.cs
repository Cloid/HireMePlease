using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockEventUI : MonoBehaviour
{
    public float timeStart = 15;
    public Text textBox;
    public GameObject eventClock;
    public GameObject meetingDoor;
    public GameObject meetingDoorTrig;
    public GameObject eventCollsion;
    private bool callOnce = false;
    private void Start()
    {
        textBox.text = timeStart.ToString();
    }
    void Update() {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        
        if(timeStart <= 5 && callOnce== false){
            callOnce = true;
            doorClose();
        }


        if(timeStart <= 0)
        {
            //end game
            timeStart = 15;
            textBox.text = "0";
            callOnce = false;
            eventCollsion.SetActive(false);
            meetingDoorTrig.SetActive(true);
            eventClock.SetActive(false);

        }
    }


    private void doorClose(){
        meetingDoor.GetComponent<DoorController>().onMeetingDoorExit(1);
    }
}
