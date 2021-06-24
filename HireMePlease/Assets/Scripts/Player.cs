using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;


public class Player : MonoBehaviour
{
    //Player Speed Movement
    public float speed = 5f;

    //Vector Intilization for movements
    Vector3 forward;
    Vector3 right;

    //Bools for task
    private bool _inTask;
    private bool oneTime;
    public GameObject ProgressBar_GO;
    public ProgressBar progressBar;
    public float barValue;
    private Vector3 lastDir;
    private Vector3 lastHeading;
    public float dashDist = 1.0f;

    private KeyCode[] keycodes = new KeyCode[] 
    {
        KeyCode.W, KeyCode.A,
        KeyCode.S, KeyCode.D,

        KeyCode.UpArrow, KeyCode.LeftArrow,
        KeyCode.DownArrow, KeyCode.RightArrow 
    };

    // Start is called before the first frame update
    void Start()
    {
        //Getting Forward Vector
        forward = Camera.main.transform.forward;
        //Manually change y for edge case of not floating randomly
        forward.y = 0;
        //Gives space to not "flip" the player
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Get current value of Slider
        barValue = ProgressBar_GO.GetComponent<Slider>().value;

        //If inside a Task Trigger Area and Holding Space, proceed
        if(_inTask && Input.GetKey(KeyCode.Space)){
            
            //If Task is done, don't update otherwise update progress
            if(barValue >= 1){
                ProgressBar_GO.SetActive(false);
            } else {
                updateProgess();
            }
        }
        
        //Input Movements
        //add keys by adding them to the keycodes list
        if(keycodes.Any(code => Input.GetKey(code))) {
            Move();
            //Debug.Log(keycodes.Any(code => Input.GetKey(code)));
        }
        //dash handler
        Dash();
    }

    private void Move(){
        //Vector intilization for movements and edge cases for flipping/normalizing
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        lastDir = direction;
        lastHeading = heading;
    }

    private void OnTriggerEnter(Collider other) {
        //If inside Task Trigger area, make bool true
        if(other.CompareTag("Task")){
            _inTask = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        //If exiting Task Trigger area, make bool false and set to 0
        //If the Progress Bar value is less than 1, don't show after exiting
        if(other.CompareTag("Task")){
            _inTask = false;
            ProgressBar_GO.GetComponent<Slider>().value = 0;
            if(barValue < 1){
                ProgressBar_GO.SetActive(false);
            }
        }
    }
    
    //Set's ProgressBar active and increment it
    private void updateProgess(){
        ProgressBar_GO.SetActive(true);
        progressBar.IncrementProgress(.001f);
    }

    // do dash
    private void Dash(){
        if (Input.GetKeyDown(KeyCode.F)) {
            TryDash(lastHeading, dashDist);
            //transform.position += lastHeading * dashDist;
        }
    }

    //move if you can, stay if you cant
    private bool TryDash(Vector3 moveHeading, float distance) {
        bool canMove = CanMove(moveHeading, distance);
        if (canMove) {
            lastHeading = moveHeading;
            transform.position += lastHeading * distance;
            return true;
        }
        else {
            return false;
        }
    }
    //was canDash
    //make sure we dont move through solid things
    private bool CanMove(Vector3 dir, float dist) {
        return Physics2D.Raycast(transform.position, dir, dist).collider == null;
    }
}
