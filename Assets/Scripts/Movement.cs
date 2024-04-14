using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float turnSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(-speed* Time.deltaTime , 0,0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-turnSpeed * Time.deltaTime,0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,turnSpeed * Time.deltaTime,0);
        }
        
    }
}
