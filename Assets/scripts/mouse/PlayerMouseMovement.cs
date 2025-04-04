using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{

    public Transform mouse;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mouse.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mouse.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mouse.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mouse.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
