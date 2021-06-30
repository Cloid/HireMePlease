using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TaskInteraction : MonoBehaviourPun
{
    [SerializeField] private float _range = 10.0f;
    private Interactible _target;

    private void Awake() {
        if(!photonView.IsMine){return;}
        StartCoroutine(SearchForInteraction());
    }
    // Start is called before the first frame update
    private IEnumerator SearchForInteraction(){
        while(true) {
            Interactible newTarget = null;
            Interactible[] interactionList = FindObjectsOfType<Interactible>();
        
            foreach(Interactible interactible in interactionList){
                float distance = Vector3.Distance(transform.position, interactible.transform.position);
                if(distance > _range) {continue;}

                //FOUND INTERACTION
                newTarget = interactible;
                //TaskPopup.Instance.CurrentInteractible = _target;

                break;
            }

            if(TaskPopup.Instance.CurrentInteractible != newTarget &&
                TaskPopup.Instance.CurrentInteractible != null){
                TaskPopup.Instance.CurrentInteractible.Use(false);
            }

            _target = newTarget;
            TaskPopup.Instance.CurrentInteractible = _target;

            yield return new WaitForSeconds(0.25f);
        }
    }

}
