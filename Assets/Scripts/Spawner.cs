using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //SCRIPT CONNECTED TO PLAYER

    // not using currently - mia
    // public Transform spawnPoint;

    //GameObjects to be spawned: enemies and fieldsword
    public GameObject Stalker;
    public GameObject pumpking;
    public GameObject Shadev2;
    public GameObject fieldsword;
    public GameObject Player;

    //Enemy Max Spawn

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

    // TODO probably will need to add random spawn locations for enemies too so they don't randomly fall off the map/spawn in inacessible areas

    //Max number of enemies (stalker and pumpking) allowed on field at a time
    const int MAX_ENEMY = 20+1;
    //enemy count (stalker and pumpking) reference
    int enemyCount = 0;
    //shade enemy count, only 1!
    int shadeCount = 0;

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
        int randomNum = Random.Range(0,5); //Random.Range(inclusive, exclusive)
        Debug.Log("Spawn Area: "+randomNum);
        Vector3 randomSpawnPoint = swordSpawns[randomNum];//index begins at 0
        Instantiate(this.fieldsword, randomSpawnPoint, Quaternion.identity); // Quat.identity = no rotation
        Debug.Log("Added a Sword");

        //spawns a singular shade, default spawn coordinates are coordinates in prefab
        Instantiate(this.Shadev2);
        shadeCount++;

        //Spawning enemy in timed intervals
        InvokeRepeating ("Spawn", startSpawnTime, spawnTime);
    }
 
    void Update () {
     
    }
 
    private void Spawn () {
        if (enemyCount < MAX_ENEMY) {
            //Randomly chooses enemy to spawn 1 = stalker, 2 pumpking)
            //spawns an enemy, default spawn coordinates are coordinates in prefab, may need to specify spawn points
            int rndNum = Random.Range(1,3);//Random.Range(inclusive, exclusive)
            Debug.Log("Random number: " + rndNum);
            if (rndNum == 1){
            Instantiate(this.Stalker);
            }
            else {
            Instantiate(this.pumpking);
            }
            enemyCount++;
            Debug.Log("spawned");
        }
    }

    private void OnTriggerEnter(Collider other){
        // running into sword
        if (other.gameObject.CompareTag("FieldWeap")) {
            Debug.Log("if field weap");
            Destroy(other.gameObject);
            Debug.Log("destroyed");
            playerWeapon.SetActive(true);
        }
        // running into "enemy" tags
        else if (other.gameObject.CompareTag("Enemy")){
            Debug.Log("Ran into an enemy took damage!");
        }
        //running into shade GAME OVER?
        else if (other.gameObject.CompareTag("Shade")){
            Debug.Log("Ran into Shade. You Died!!!");
        }
    }
 
}