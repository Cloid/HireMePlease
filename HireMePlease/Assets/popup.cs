using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour
{
    public Image popup1;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("changeSprite", 4);

    }

    public void changeSprite()
    {
        int temp = Random.Range(0, 3);

        if(temp == 0)
        {
            popup1.sprite = image1;
        }
        else if(temp == 1)
        {
            popup1.sprite = image2;
        }
        else if(temp == 2)
        {
            popup1.sprite = image3;
        }
    }
}
