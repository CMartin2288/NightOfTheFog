using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
 
    public Transform spawnPoint;
    public GameObject Stalker;
 
    public int startSpawnTime = 5;
    public int spawnTime = 10;
 
 
    void Start () {
        InvokeRepeating ("Spawn", startSpawnTime, spawnTime);
    }
 
    void Update () {
     
    }
 
    void Spawn () {

        Instantiate(this.Stalker);
    }
 
}