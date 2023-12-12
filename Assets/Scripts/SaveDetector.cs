using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class SaveDetector : MonoBehaviour
{
    public bool validSave = false;
    //The Windows save file for the game is found in C:\Users\<<username>>\AppData\LocalLow\DefaultCompany\NightOfFog
    private string saveFile;
    public GameObject continueButton;
    
    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath+"/save.json";
        if(File.Exists(saveFile))
        {
            JsonUtility.FromJsonOverwrite(File.ReadLines(saveFile).First(), this);
            //Update the continue button based on the 
            continueButton.GetComponent<Button>().interactable = validSave;
        }
    }

    public void SetToLoad()
    {
        SaveManager.shouldLoad = true;
    }
}
