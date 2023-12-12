using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    public static bool shouldLoad = false;
    //The Windows save file for the game is found in C:\Users\<<username>>\AppData\LocalLow\DefaultCompany\NightOfFog
    private string saveFile;
    
    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath+"/save.json";
        
        //ShouldLoad is set by the Save Detector after clicking the continue button from the main menu
        if(shouldLoad)
        {
            print("The game will load data here");
        }
    }
}
