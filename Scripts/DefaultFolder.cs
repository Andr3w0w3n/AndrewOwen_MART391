﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFolder : MonoBehaviour
{
    public string folderDirectory;
    public string homeDirectory;
    public new string name;
    public bool onFolder = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        if (onFolder)
        {

        }
    }
}
