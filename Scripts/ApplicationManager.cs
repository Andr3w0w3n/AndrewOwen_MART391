using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ApplicationManager : MonoBehaviour
{
    public string defaultDirectory = @"C:\Users\epica\OneDrive\Documents";
    public static ApplicationManager instance;
    //assign the instance as "this" if none currently exist
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        //May uncomment this when I figure out how to make this application ready for VR
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
