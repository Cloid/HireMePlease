using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTaskLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trashCan;
    public GameObject trashPieces;
    public GameObject canvas;
    public Transform Spawner;
    public float radius = 1f;

    private void OnEnable() {
        for(int i = 0; i <= 4; i++){
            //Debug.Log("SPAWN: " + i);
            //float angle = i * Mathf.PI*2f / 4;
            //Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, 1, Mathf.Sin(angle)*radius);
            //var position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(trashPieces, Random.insideUnitSphere * 4 + Spawner.position, Quaternion.identity).transform.SetParent(canvas.transform);

        }
        StartCoroutine(CheckTaskCompletion());
    }

    // Update is called once per frame
    private IEnumerator CheckTaskCompletion(){
        while(trashCan.GetComponent<TrashCanScript>().trashCount != 5){
            Debug.Log("Not Finished Trash Task");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("TRASH TASK COMPLETE");
        //Giving Player Points when Task is done
        Player currPlayer = GetComponent<GetPlayer>().player.GetComponent<Player>();
        currPlayer.taskComplete();
        
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        GameObject[] trashPieces = GameObject.FindGameObjectsWithTag("Trash");
        foreach(GameObject piece in trashPieces)
        GameObject.Destroy(piece);
    }

}
