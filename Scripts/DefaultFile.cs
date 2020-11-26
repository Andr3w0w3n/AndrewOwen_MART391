using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using TMPro;


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
        //get the delete icon bool here and make sure to delete the file and then the object here
        if (this.gameObject.transform.Find("DeleteIcon").gameObject.GetComponent<DeleteIcon>().delete)
        {
            File.Delete(directory);
            Object.Destroy(this.gameObject);
        }
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
