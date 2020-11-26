using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFolder : MonoBehaviour
{
    public string folderDirectory;
    public string homeDirectory;
    public new string name;
    public bool changeDirectory = false;
    public GameObject selectCircle;
    public float selectTimer = 7f;

    void OnMouseOver()
    {
        if (!ApplicationManager.instance.circleExist)
        {
            GameObject circle = Instantiate(selectCircle, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.03f), Quaternion.identity);
            circle.GetComponent<TargetCircle>().timer = 2f;
            circle.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
        }
        if (ApplicationManager.instance.circleExist == true)
        {
            if (GameObject.FindWithTag("SelectCircle") != null)
            {
                if (GameObject.FindWithTag("SelectCircle").GetComponent<TargetCircle>().done)
                {
                    changeDirectory = true;
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