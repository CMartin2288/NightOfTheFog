using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MouseShowing : MonoBehaviour

{
    private TimeSpan displayTimer;
    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        displayTimer = TimeSpan.FromSeconds(SaveManager.timer);
        timerText.text += displayTimer.ToString(@"mm\:ss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
