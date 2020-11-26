using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    public float timer = 5.0f;
    private float time = 0f;
    private float scale = 0.275f;
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationManager.instance.circleExist = true;
        this.transform.localScale = new Vector3(0.275f, 0.275f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //scale down section
        //this.transform.localScale = new Vector3(this.transform.localscale.x-0.01, 2.0f, 2.0f);
        if(!ApplicationManager.instance.circleExist)
            Object.Destroy(this.gameObject);

    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time >= timer && !done)
            done = true;
        this.transform.localScale = new Vector3(this.transform.localScale.x - (scale/(timer/0.02f)), this.transform.localScale.y - (scale / (timer / 0.02f)), 0);
    }
}
