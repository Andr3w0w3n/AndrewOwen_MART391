using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : MonoBehaviour
{
    public bool downClicked = false;
    private bool over = false;
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
        over = true;
    }
    void OnMouseExit()
    {
        over = false;
    }
    void OnMouseDown()
    {
        if (over)
            downClicked = true;
    }
}
