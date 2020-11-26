using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    string stringToEdit = "Hello World";
    private bool submitted = false;
    public GameObject rUSure;
    private GameObject textConf;

    void OnGUI()
    {
        // Make a text field that modifies stringToEdit.
        stringToEdit = GUILayout.TextField(stringToEdit, 25);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("Enter") && !submitted)
        {
            ApplicationManager.instance.defaultDirectory = stringToEdit;
            submitted = true;
            textConf = Instantiate(rUSure, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }
    
}
