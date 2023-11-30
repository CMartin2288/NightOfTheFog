using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
 
    // public Transform spawnPoint;
    public GameObject Stalker;
    // public GameObject pumpking;
    // public GameObject Shadev2;
    public GameObject fieldsword;
 
    public int startSpawnTime = 5;
    public int spawnTime = 10;

    public Vector3 swordSpawn1 = new Vector3(-110.72f,-3.59f,104.97f);
    // public Vector3 swordSpawn2 = (-110.72,-3.59,104.97);
    // public Vector3 swordSpawn3 = (-110.72,-3.59,104.97);
    // public Vector3 swordSpawn4 = (-110.72,-3.59,104.97);
    // public Vector3 swordSpawn5 = (-110.72,-3.59,104.97);


    void Start () {
        List<Vector3> swordSpawns = new List<Vector3>();
        swordSpawns.Add(swordSpawn1);
        Vector3 randomSpawnPoint = swordSpawn1;
        Instantiate(this.fieldsword, randomSpawnPoint, Quaternion.identity);
        Debug.Log("Added a Sword");
        InvokeRepeating ("Spawn", startSpawnTime, spawnTime);
    }
 
    void Update () {
     
    }
 
    void Spawn () {
        // vector3 randomSpawnPosition=new vector3
        Instantiate(this.Stalker);

        Debug.Log("spawned");
    }
 
}