using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static bool shouldLoad;
    //The Windows save file for the game is found in C:\Users\<<username>>\AppData\LocalLow\DefaultCompany\NightOfFog
    private string saveFile;

    private GameObject player;
    private GameObject heldSword;
    private SaveObjects objectLinks;

    public Vector3 playerPos;
    public Quaternion playerRot;
    public int swordIndex;
    public bool hasSword;

    void Start()
    {
        saveFile = Application.persistentDataPath+"/save.json";
        objectLinks = GetComponent<SaveObjects>();
        player = GameObject.FindGameObjectWithTag("Player");
        heldSword = objectLinks._heldSword;
        
        //ShouldLoad is set by the Save Detector after clicking the continue button from the main menu
        if(shouldLoad)
        {
            Debug.Log("The game will load data here");

            string[] loadData = File.ReadAllLines(saveFile);
            JsonUtility.FromJsonOverwrite(loadData[0], this);

            player.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
            Physics.SyncTransforms();
            player.transform.rotation = new Quaternion(playerRot.x, playerRot.y, playerRot.z, playerRot.w);
            Physics.SyncTransforms();

            heldSword.SetActive(hasSword);
        }
    }

    //Update is called every frame, needed to load data for spawned objects
    void Update()
    {

    }

    public void SaveQuit()
    {
        //Retrieve current 
        playerPos = player.transform.position;
        playerRot = player.transform.rotation;
        hasSword = heldSword.activeSelf;
        
        List<string> saveData = new List<string>{};

        saveData.Add(JsonUtility.ToJson(this));

        File.WriteAllLines(saveFile, saveData);

        Application.Quit();
    }
}
