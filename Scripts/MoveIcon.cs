using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onMouseOver()
    {
        Debug.Log("I am over the button!");
        GameObject actionMenu = Instantiate(menu, new Vector3(18.6f, 0.4f, 0), Quaternion.identity);
        actionMenu.transform.localScale = new Vector3(1.02f, 0.82f, 0);
    }
}
