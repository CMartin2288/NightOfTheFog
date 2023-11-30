using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //SCRIPT CONNECTED TO PLAYER

    // not using currently - mia
    // public Transform spawnPoint;

    //GameObjects to be spawned: enemies and fieldsword
    //Object maximums
    public GameObject Stalker;
    // public GameObject pumpking;
    // public GameObject Shadev2;
    public GameObject fieldsword;

    //reference to PlayerWeapon to help determine collisions with sword and pickUp
    GameObject playerWeapon;

 
    //first monster spawns after
    public int startSpawnTime = 5;
    //monsters spawn every <spawnTime> seconds
    public int spawnTime = 10;

    // predertermined spawn points (due to having to take into account height)
    public Vector3 swordSpawn1 = new Vector3(-110.72f,-3.59f,104.97f);
    public Vector3 swordSpawn2 = new Vector3(35.54f,12.33f,90.26f);
    public Vector3 swordSpawn3 = new Vector3(-34.95f,-1.93f,-47.64f);
    public Vector3 swordSpawn4 = new Vector3(3.31f,6.22f,-180.60f);
    public Vector3 swordSpawn5 = new Vector3(93.18f,-2.10f,57.52f);


    void Start () {
        //hides player sword until obtained
        playerWeapon = GameObject.FindWithTag("HoldWeap");
        playerWeapon.SetActive(false);

        //spawns a sword from a randomly chosen coordinate out of 5 predetermined locations
        List<Vector3> swordSpawns = new List<Vector3>();
        swordSpawns.Add(swordSpawn1);
        swordSpawns.Add(swordSpawn2);
        swordSpawns.Add(swordSpawn3);
        swordSpawns.Add(swordSpawn4);
        swordSpawns.Add(swordSpawn5);
        int randomNum = Random.Range(1,5);
        Debug.Log("Spawn Area: "+randomNum);
        Vector3 randomSpawnPoint = swordSpawns[randomNum];//index begins at 0, range inclusive
        Instantiate(this.fieldsword, randomSpawnPoint, Quaternion.identity);
        Debug.Log("Added a Sword");

        InvokeRepeating ("Spawn", startSpawnTime, spawnTime);
    }
 
    void Update () {
     
    }
 
    private void Spawn () {
        // vector3 randomSpawnPosition=new vector3
        Instantiate(this.Stalker);

        Debug.Log("spawned");
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("collision detected");
        if (other.gameObject.CompareTag("FieldWeap")) {
            Debug.Log("if field weap");
            Destroy(other.gameObject);
            Debug.Log("destroyed");
            // Instantiate(this.heldsword);
            playerWeapon.SetActive(true);
        }
    }
 
}