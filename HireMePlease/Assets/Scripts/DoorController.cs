using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += onDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += onDoorwayExit;
    }

    // Update is called once per frame
    private void onDoorwayOpen(int id)
    {
        if(id == this.id)
        LeanTween.moveLocalY(gameObject, 3.32f, 1f).setEaseOutQuad();
    }

    private void onDoorwayExit(int id)
    {
        if(id == this.id)
        LeanTween.moveLocalY(gameObject, -8.5f, 1f).setEaseInQuad();
    }

    private void OnDestroy() {
        GameEvents.current.onDoorwayTriggerEnter -= onDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= onDoorwayExit;
    }

}
