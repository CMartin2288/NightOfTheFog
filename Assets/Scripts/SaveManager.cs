using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using TMPro;

public class SaveManager : MonoBehaviour
{
    //If the game should load progress
    public static bool shouldLoad;
    //The Windows save file for the game is found in C:\Users\<<username>>\AppData\LocalLow\DefaultCompany\NightOfFog
    private string saveFile;

    //Object Links
    private GameObject player;
    private GameObject heldSword;
    private GameObject displayTimer;
    public static float timer;
    private TimeSpan shownTime;

    //Save Data
    public Vector3 playerPos;
    public Quaternion playerRot;
    public int swordIndex;
    public bool hasSword;
    public float savedTimer;
    public int savedHealth;

    void Start()
    {
        saveFile = Application.persistentDataPath+"/save.json";
        player = GameObject.FindGameObjectWithTag("Player");
        heldSword = GameObject.FindGameObjectWithTag("HoldWeap");
        displayTimer = GameObject.FindGameObjectWithTag("Timer");
        
        //ShouldLoad is set by the Save Detector after clicking the continue button from the main menu
        if(shouldLoad)
        {
            //Load save data into this class's variables
            string[] loadData = File.ReadAllLines(saveFile);
            JsonUtility.FromJsonOverwrite(loadData[0], this);

            //Update player transforms
            player.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
            Physics.SyncTransforms();
            player.transform.rotation = new Quaternion(playerRot.x, playerRot.y, playerRot.z, playerRot.w);
            Physics.SyncTransforms();
            
            //Update Game Timer
            timer = savedTimer;
        }
    }

    //Update is called every frame, needed to load data for spawned objects
    void Update()
    {
        timer += Time.deltaTime;
        
        shownTime = TimeSpan.FromSeconds(timer);
        
        displayTimer.GetComponent<TMP_Text>().text = shownTime.ToString(@"mm\:ss");
    }

    public void SaveQuit()
    {
        //Retrieve current values
        playerPos = player.transform.position;
        playerRot = player.transform.rotation;
        hasSword = heldSword.activeSelf;
        savedTimer = timer;
        
        List<string> saveData = new List<string>{};

        saveData.Add(JsonUtility.ToJson(this));

        File.WriteAllLines(saveFile, saveData);

        Application.Quit();
    }
}
