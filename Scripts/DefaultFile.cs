﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DefaultFile : MonoBehaviour
{
    public string directory;
    public new string name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void assignPath(string p)
    {
        directory = p;
        name = Path.GetFileName(p);
    }
    public string getPath()
    {
        return directory;
    }
}
