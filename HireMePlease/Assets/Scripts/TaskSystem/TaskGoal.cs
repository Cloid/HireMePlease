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

}

public enum GoalType{
    Coffee,
    Test2
}
