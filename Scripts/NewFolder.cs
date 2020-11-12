using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
//using System.Diagnostics;

public class NewFolder : MonoBehaviour
{
    private string defaultDir; //this will be the directory that will be defaulted from the start screen
    private Boolean onFolder;
    //public GameObject fileFolder;
    //private Boolean mouseOver;
    // Start is called before the first frame update
    void Start()
    {
        defaultDir = ApplicationManager.instance.defaultDirectory;
        onFolder = false;
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }*/

    void OnMouseOver()
    {
        onFolder = true;
    }
    void OnMouseExit() 
    { 
        onFolder = false;
    }
    void OnMouseDown()
    {
        if(onFolder == true)
        {
            //puts all file names into a string array
            string[] files = Directory.GetFiles(defaultDir);
            string[] directories = Directory.GetDirectories(defaultDir);
            for (int i = 0; i < directories.Length - 1; i++)
            {
                string result;
                result = Path.GetFileName(directories[i]);
                Debug.Log(result);
            }
            for (int i = 0; i < files.Length - 1; i++)
            {
                string result;
                result = Path.GetFileName(files[i]);
                Debug.Log(result);
            }
        }
    }
}
