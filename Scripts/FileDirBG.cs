using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.InteropServices;
using TMPro;

public class FileDirBG : MonoBehaviour
{
    public GameObject DefaultFile;
    public GameObject PictureFile;
    public GameObject Folder;
    public string directory;
    private TextMeshPro Text;

    // Start is called before the first frame update
    void Start()
    {
        
        string[] files = Directory.GetFiles(directory);
        string[] directories = Directory.GetDirectories(directory);
        for (int i = 0; i < directories.Length - 1; i++)
        {
            string folderName = Path.GetFileName(directories[i]);
            GameObject NewFolder = Instantiate(Folder, new Vector3(0, 2.5f, -0.05f), Quaternion.identity);
            NewFolder.GetComponent<DefaultFolder>().folderDirectory = directories[i];
            NewFolder.GetComponent<DefaultFolder>().name = folderName;
            NewFolder.GetComponent<DefaultFolder>().homeDirectory = directory;
            Text = FindObjectOfType<TextMeshPro>();
            if (folderName.Length > 10)
                folderName = folderName.Substring(0,9);
            Text.text = folderName;
        }
        for (int i = 0; i < files.Length - 1; i++)
        {
            string fileName = Path.GetFileName(files[i]);
            GameObject NewFile = Instantiate(DefaultFile, new Vector3(0, 2.5f, -0.05f), Quaternion.identity);
            NewFile.GetComponent<DefaultFile>().directory = files[i];
            NewFile.GetComponent<DefaultFile>().name = fileName;
            Text = FindObjectOfType<TextMeshPro>();
            if (fileName.Length > 11)
                fileName = fileName.Substring(0,10);
            Text.text = fileName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setDirectory(string dir)
    {
        directory = dir;
    }
    public string getDirectory()
    {
        return directory;
    }
}
