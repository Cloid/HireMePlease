using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private GameObject _taskWindow;

    public void Use(bool isActive){
        _taskWindow.SetActive(isActive);
    }

}
