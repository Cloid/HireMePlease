using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {
    public float timeStart = 10;
    public Text textBox;
    public GameObject leaderboard;

    private void Start()
    {
        textBox.text = timeStart.ToString();
    }
    void Update() {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        if(timeStart <= 0)
        {
            //end game
            textBox.text = "0";
            leaderboard.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
