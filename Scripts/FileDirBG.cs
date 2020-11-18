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
    public float position1;
    public float position2;
    public float position3;
    public float position4;
    public float position5;
    public float position6;
    private int sectionPos;
    private bool lockUp = false;
    private bool lockDown = false;
    
    //I am thinking about creating a list to make the file folder able to hop back a folder and go forward. This will probably be implemented later in the project however. 

    //initialize the position markers, Each folder and file object will be a child of the background so the locations are in relation to the BG
    //all locations are as follows {0,1,2,3,4,5} -> 0 1 2
    //                                              3 4 5
    private Vector3[] filePositions = { /*top of BG*/new Vector3(-6f,2.3f,-1f),
            new Vector3(-1f,2.3f,-1f),
            new Vector3(4.75f, 2.3f, -1f), 
            //bottom of BG 
            new Vector3(-6f, -1.75f, -1f),
            new Vector3(-1f, -1.75f, -1f),
            new Vector3(4.75f, -1.75f, -1f)};
    private Vector3[] folderPositions = { /*top of BG*/new Vector3(-5.5f, 2.4f, -1f),
                new Vector3(-0.5f, 2.4f, -1f),
                new Vector3(5.3f, 2.4f, -1f),
                //bottom of BG
                new Vector3(-5.6f, -1.85f, -1f),
                new Vector3(-0.5f, -1.85f, -1f),
                new Vector3(5.3f, -1.85f, -1f)};
    private string[] allFileDir;

    // Start is called before the first frame update
    void Start()
    {
        //Some more variable intializations
        sectionPos = 0;

        //getting all the files from the default directory
        string[] files = Directory.GetFiles(directory);
        string[] directories = Directory.GetDirectories(directory);

        //merge them arrays into the big one
        allFileDir = new string[files.Length + directories.Length];
        directories.CopyTo(allFileDir, 0);
        files.CopyTo(allFileDir, directories.Length);

        //
        GenerateIcons();
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void FixedUpdate()
    {
        //code to change opacity: SpriteRenderer.color = new Color(1f,1f,1f,.5f) is 50% transparent, last number is the opacity
        //check to see if we are at the limit of the scroll is reached and if one of the arrows needs to faded out
        if (sectionPos == 0)
        {
            this.gameObject.transform.Find("UpArrow").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            lockUp = true;
        }
        //these next two else if statements decide if the number of files is divisable by 6 and locks the down arrow appropriately so
        else if (allFileDir.Length % 6 == 0 && sectionPos == ((allFileDir.Length / 6) - 1))
        {
            this.gameObject.transform.Find("DownArrow").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            lockDown = true;
        }
        else if (sectionPos == allFileDir.Length / 6)
        {
            this.gameObject.transform.Find("DownArrow").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            lockDown = true;
        }
        //otherwise, they are both unlocked
        else
        {
            this.gameObject.transform.Find("UpArrow").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            this.gameObject.transform.Find("DownArrow").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            lockUp = false;
            lockDown = false;
        }         

        //check to see if one of the arrows were pressed, if so, change files
        //this section is confusing wording wise, the down arrow advances the folder contents and the up arrow receeds the contents
        if (this.gameObject.transform.Find("DownArrow").GetComponent<DownArrow>().downClicked && !lockDown)
        {
            sectionPos++;
            this.gameObject.transform.Find("DownArrow").GetComponent<DownArrow>().downClicked = false;
            DeleteAllIconChildren();
            GenerateIcons();

        }
        else if (this.gameObject.transform.Find("UpArrow").GetComponent<UpArrow>().upClicked && !lockUp)
        {
            sectionPos--;
            this.gameObject.transform.Find("UpArrow").GetComponent<UpArrow>().upClicked = false;
            DeleteAllIconChildren();
            GenerateIcons();
        }
    }

    //this is where the magic of creating each of the icons to put on the background happens. 
    void GenerateIcons()
    {
        //gotta create this for the placement position reference
        int placementPosition = 0;
        for (int i = 6*sectionPos; i < 6*sectionPos+6 && i < allFileDir.Length; i++)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(allFileDir[i]);
            //is it a directory?
            if (attr.HasFlag(FileAttributes.Directory))
            {
                string folderName = Path.GetFileName(allFileDir[i]);
                GameObject NewFolder = Instantiate(Folder, new Vector3(0,0,0), Quaternion.identity);
                NewFolder.transform.parent = this.transform;
                NewFolder.transform.localPosition = folderPositions[placementPosition];
                NewFolder.GetComponent<DefaultFolder>().folderDirectory = allFileDir[i];
                NewFolder.GetComponent<DefaultFolder>().name = folderName;
                NewFolder.GetComponent<DefaultFolder>().homeDirectory = directory;
                Text = FindObjectOfType<TextMeshPro>();
                if (folderName.Length > 10)
                    folderName = folderName.Substring(0, 9);
                Text.text = folderName;
            }
            //must be a file
            else
            {
                string fileName = Path.GetFileName(allFileDir[i]);
                GameObject NewFile = Instantiate(DefaultFile, new Vector3(0, 0, 0), Quaternion.identity);
                NewFile.transform.parent = this.transform;
                NewFile.transform.localPosition = folderPositions[placementPosition];
                NewFile.GetComponent<DefaultFile>().directory = allFileDir[i];
                NewFile.GetComponent<DefaultFile>().name = fileName;
                Text = FindObjectOfType<TextMeshPro>();
                if (fileName.Length > 11)
                    fileName = fileName.Substring(0, 10);
                Text.text = fileName;
            }

            placementPosition++;
        }
    }


    void DeleteAllIconChildren()
    {
        var icons = new List<GameObject>();
        //loop over all children, put only the ones with the tag "icon" into list
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Icon")
                icons.Add(child.gameObject);
        }
        //destroy all child objects in list
        icons.ForEach(child => Destroy(child));
    }
    //some setter and getter method for my directory value
    //Edit: Do I need a setter and getter for it? I have used other ways of getting info before with the ApplicationManager
}