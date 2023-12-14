using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class SaveDetector : MonoBehaviour
{
    //The Windows save file for the game is found in C:\Users\<<username>>\AppData\LocalLow\DefaultCompany\NightOfFog
    private string saveFile;
    public GameObject continueButton;
    
    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath+"/save.json";
        if(File.Exists(saveFile))
        {
            //Enable the continue button
            continueButton.GetComponent<Button>().interactable = true;
        }
    }

    public void SetToLoad()
    {
        SaveManager.shouldLoad = true;
    }

    public void SetToNotLoad()
    {
        SaveManager.shouldLoad = false;
    }
}
