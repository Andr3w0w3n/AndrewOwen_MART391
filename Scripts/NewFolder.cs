using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
//using System;
using System.Runtime.InteropServices;
using TMPro;
//using System.Diagnostics;

public class NewFolder : MonoBehaviour
{
    private string defaultDir; //this will be the directory that will be defaulted from the start screen
    public GameObject FileDirBG;
    public GameObject selectCircle;
    public float selectTimer = 2f;
    public bool makeFolder = false;
    private bool locked = false;

    //placements are odd, with first one in front, next one to the right, then swapping until the final one in back
    private Vector3[] dirViewPos =
    {
        new Vector3(0,1.8f,0),
        new Vector3(9.7f,1.8f,-5f),
        new Vector3(-9.5f,1.8f,-6.1f),
        new Vector3(10.5f,1.8f,-16f),
        new Vector3(-8.6f,1.8f,-17.5f),
        new Vector3(1.2f,1.8f,-22f)
    };
    private float[] dirViewRot =
    {
        /*Quaternion.Euler(0,0,0),
        Quaternion.Euler(0,60f,0),
        Quaternion.Euler(0,300f,0),
        Quaternion.Euler(0,120f,0),
        Quaternion.Euler(0,240f,0),
        Quaternion.Euler(0,180f,0)*/
        0, 60f, 300f, 120f, 240f, 180f
    };
    //public GameObject fileFolder;
    //private Boolean mouseOver;
    // Start is called before the first frame update
    void Start()
    {
        defaultDir = ApplicationManager.instance.defaultDirectory;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(ApplicationManager.instance.directoryCount >= 6)
        {
            this.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            locked = true;
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            locked = false;
        }
    }

    void OnMouseOver()
    {
        if (!locked)
        {
            if (!ApplicationManager.instance.circleExist)
            {
                GameObject circle = Instantiate(selectCircle, new Vector3(-0.04f, -3.15f, -0.3f), Quaternion.identity);
                circle.GetComponent<TargetCircle>().timer = 2f;
                circle.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
            }
            if (ApplicationManager.instance.circleExist == true)
            {
                if (GameObject.FindWithTag("SelectCircle") != null)
                {
                    if (GameObject.FindWithTag("SelectCircle").GetComponent<TargetCircle>().done)
                    {
                        createFolder();
                        Object.Destroy(GameObject.FindWithTag("SelectCircle").gameObject);
                    }
                }
            }
        }
    }
    void OnMouseExit() 
    { 
        ApplicationManager.instance.circleExist = false;
    }
    private void createFolder()
    {
        GameObject NewDefaultFolder = Instantiate(FileDirBG, dirViewPos[ApplicationManager.instance.directoryCount], Quaternion.identity);
        NewDefaultFolder.transform.Rotate(0, dirViewRot[ApplicationManager.instance.directoryCount], 0);
        NewDefaultFolder.GetComponent<FileDirBG>().directory = defaultDir;
        ApplicationManager.instance.directoryCount++;
    }
}
