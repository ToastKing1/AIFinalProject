using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBillboard : MonoBehaviour
{

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the text face the camera
        transform.rotation = camera.transform.rotation;
    }
}
