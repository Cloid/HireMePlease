using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverDestroy : MonoBehaviour
{
    public int playerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void playerFix(int idx){
        playerIndex = idx;
    }

    public int returnIdx(){
        return this.playerIndex;
    }

}
