using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Photon.Pun;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    //Player Speed Movement
    public float speed = 10.0f;

    //Vector Intilization for movements
    Vector3 forward;
    Vector3 right;

    //Bools for task
    private bool _inTask;
    private bool oneTime;
    //public GameObject ProgressBar_GO;
    //public ProgressBar progressBar;
    public float barValue;
    private Vector3 lastDir;
    private Vector3 lastHeading;
    //[Range(1.0f, 10.0f)] // dash dist
    public float dashForce = 1000.0f;
    public float dashCooldown = 2.2f;
    private float nextDashAvailable = 0.0f; 

    public PhotonView photonView;

    //List of Tasks for Player
    public List<Task> TaskList = new List<Task>();
    //Unique Random Int list
    public List<int> randomInts = new List<int>();
    //taskID for Tasks
    private int taskID = -1;
    //Amount of tasks for player
    private int taskCount = 3;
    //Task Done for Player
    public int taskDone = 0;
    public int bonusPt = 0;
    public bool callOnce = false;
    private KeyCode[] keycodes = new KeyCode[]
    {
        KeyCode.W, KeyCode.A,
        KeyCode.S, KeyCode.D,

        KeyCode.UpArrow, KeyCode.LeftArrow,
        KeyCode.DownArrow, KeyCode.RightArrow
    };

    private void Awake() {
        generateThreeTasks();    
        TaskList[taskDone].changeTaskUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting Forward Vector
        forward = Camera.main.transform.forward;
        //Manually change y for edge case of not floating randomly
        forward.y = 0;
        //Gives space to not "flip" the player
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (photonView.IsMine)
        {
            //dash handler
            DashHandler();
        }
    }
    void FixedUpdate()
    {
        // //Get current value of Slider
        // barValue = ProgressBar_GO.GetComponent<Slider>().value;

        // //If inside a Task Trigger Area and Holding Space, proceed
        // if(_inTask && Input.GetKey(KeyCode.Space)){

        //     //If Task is done, don't update otherwise update progress
        //     if(barValue >= 1){
        //         ProgressBar_GO.SetActive(false);
        //     } else {
        //         updateProgess();
        //     }
        // }

        //Input Movements
        //add keys by adding them to the keycodes list
        if (photonView.IsMine)
        {
            //dont touch the lambda
            if (keycodes.Any(code => Input.GetKey(code)))
            {
                Move();
                //Debug.Log(keycodes.Any(code => Input.GetKey(code)));
            }
        }
    }
    private void Move()
    {
        //Vector intilization for movements and edge cases for flipping/normalizing
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        

        //rb.MovePosition(transform.position + rightMovement);
        //rb.MovePosition(transform.position + upMovement);
        if (canMove(heading, 0.7f)) {
            transform.position += rightMovement;
            transform.position += upMovement;
        }
        
        lastDir = direction;
        lastHeading = heading;
    }

    // private void OnTriggerEnter(Collider other) {
    //     //If inside Task Trigger area, make bool true
    //     if(other.CompareTag("Task")){
    //         _inTask = true;
    //     }
    // }

    // private void OnTriggerExit(Collider other) {
    //     //If exiting Task Trigger area, make bool false and set to 0
    //     //If the Progress Bar value is less than 1, don't show after exiting
    //     if(other.CompareTag("Task")){
    //         _inTask = false;
    //         ProgressBar_GO.GetComponent<Slider>().value = 0;
    //         if(barValue < 1){
    //             ProgressBar_GO.SetActive(false);
    //         }
    //     }
    // }

    //Set's ProgressBar active and increment it
    // private void updateProgess(){
    //     ProgressBar_GO.SetActive(true);
    //     progressBar.IncrementProgress(.001f);
    // }

    // do the dash (maybe)
    private void DashHandler(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Time.time >nextDashAvailable) {
                bonk(lastHeading, dashForce);
                nextDashAvailable = Time.time + dashCooldown;
            }
            //transform.position += lastHeading * dashDist;
        }
    }

    //slap the player in a direction like its missbehaving
    private void bonk (Vector3 heading, float force) {
        Debug.Log("heading "+heading+ "\ncalculated force "+(heading*force));
        this.GetComponent<Rigidbody>().AddForce(heading * force);
    }
    
    //was canDash
    //make sure we dont move through solid things
    private bool canMove(Vector3 dir, float dist) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, dir);
        if (Physics.Raycast(ray, out hit, dist)) {
            if (hit.collider.tag == "map") {
                return false;
            }
        }
        //Debug.Log(Physics2D.Raycast(transform.position, dir, dist));
        //return Physics.Raycast(transform.position, dir, dist) == null;
        return true;
    }

    private void newNumber()
    {
        taskID = Random.Range(0, 3);
        //Debug.Log("Current taskID: " + taskID);
        if (!randomInts.Contains(taskID))
        {
            //Debug.Log("Added to list: " + taskID);
            randomInts.Add(taskID);
        } else if(randomInts.Count != taskCount) {
            newNumber();
        }
    }
    
    public void generateThreeTasks(){
        for (int idx = 0; idx < taskCount; idx++)
        {
            //Generate a new unique int
            newNumber();
            //Add new Task script to TaskList
            TaskList.Add(new Task());
            //Look into current index and change Task's type based on taskID
            TaskList[idx].changeTaskType(taskID);
            //Debug.Log("TaskList: " + idx + " has taskID of " + taskID);
        }
        randomInts.Clear();
        Debug.Log("Count: " + TaskList.Count());
    }

    private void resetList(){
        /*if(!timerdone){
            randomInts.Clear();
        }*/
    }

    public void taskComplete(){
        Debug.Log("Task Done: " + taskDone);
        TaskList[taskDone].Complete();
        taskDone++;
        TaskList[taskDone].changeTaskUI();
    }

    public void bonusAdd(){
        if(!callOnce){
            callOnce = true;
            bonusPt++;
        }
    }

    public void bonusDc(){
        if(callOnce){
            callOnce = false;
            bonusPt--;
        }
    }

    public void addPts(){
        taskDone += bonusPt;
        bonusPt = 0;
    }

    [PunRPC]
    public void SyncValues(int total, int bonus){
        taskDone = total;
        bonusPt = bonus;
    }
}
