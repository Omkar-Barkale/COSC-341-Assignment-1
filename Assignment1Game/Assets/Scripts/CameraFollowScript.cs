using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    public float interval;
    public float zOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, target.position.x, interval), Mathf.Lerp(this.transform.position.y, target.position.y, interval), zOffset);
    }
}
