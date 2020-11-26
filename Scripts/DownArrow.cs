using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : MonoBehaviour
{
    public bool downClicked = false;
    public GameObject selectCircle;
    public float selectTime = 0.5f;
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
        if (!ApplicationManager.instance.circleExist)
        {
            GameObject circle = Instantiate(selectCircle, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.05f), Quaternion.identity);
            circle.GetComponent<TargetCircle>().timer = selectTime;
            circle.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
        }
        if (ApplicationManager.instance.circleExist == true)
        {
            if (GameObject.FindWithTag("SelectCircle") != null)
            {
                if (GameObject.FindWithTag("SelectCircle").GetComponent<TargetCircle>().done)
                {
                    downClicked = true;
                    Object.Destroy(GameObject.FindWithTag("SelectCircle").gameObject);
                }
            }
        }
    }
    void OnMouseExit()
    {
        ApplicationManager.instance.circleExist = false;
    }
}
