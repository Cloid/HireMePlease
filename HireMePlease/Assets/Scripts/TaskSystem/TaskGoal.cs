using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGoal : MonoBehaviour
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public bool isReached(){
        return (currentAmount>=requiredAmount);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GoalType{
    Test,
    Test2
}
