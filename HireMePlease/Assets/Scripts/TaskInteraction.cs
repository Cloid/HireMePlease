using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TaskInteraction : MonoBehaviourPun
{
    [SerializeField] private float _range = 10.0f;
    private Interactible _target;
    private LineRenderer _lineRenderer;

    private void Awake() {
        if(!photonView.IsMine){return;}
        _lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(SearchForInteraction());
    }

    private void Update() {
        if(!photonView.IsMine){return;}

        if(_target != null){
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _target.transform.position);
        }

        else{
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
    // Start is called before the first frame update
    private IEnumerator SearchForInteraction(){
        while(true) {
            Interactible newTarget = null;
            Interactible[] interactionList = FindObjectsOfType<Interactible>();

            //Debug.Log(interactionList);
        
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
                Debug.Log("Got too far. Disabling task");
                TaskPopup.Instance.CurrentInteractible.Use(false);
            }

            _target = newTarget;
            TaskPopup.Instance.CurrentInteractible = _target;

            yield return new WaitForSeconds(0.25f);
        }
    }

}
