using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMenu : MonoBehaviour
{
    public float waitTime = 2f;
    private float timer = 0f;
    private bool wait = true;
    private bool onMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationManager.instance.menuExist = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > waitTime)
            wait = false;
        if(!onMenu && !wait)
        {
            ApplicationManager.instance.menuExist = false;
            Object.Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }
    void onMouseExit()
    {
        ApplicationManager.instance.menuExist = false;
        Object.Destroy(this.gameObject);
    }
    void onMouseOver()
    {
        onMenu = true;
    }
}
