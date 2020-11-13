using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
using TMPro;
//using System.Diagnostics;

public class NewFolder : MonoBehaviour
{
    private string defaultDir; //this will be the directory that will be defaulted from the start screen
    private Boolean onFolder;
    public GameObject FileDirBG;
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
        //private GameObject[] files;
        if (onFolder == true)
        {
            GameObject NewDefaultFolder = Instantiate(FileDirBG, new Vector3(0, 2.5f, -0.01f), Quaternion.identity);
            NewDefaultFolder.GetComponent<FileDirBG>().directory = defaultDir;
        }
    }
}
