using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the mouse collides with the collision, the scene is set to the menu
        if (collision.gameObject.name == "Mouse")
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
