using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeoDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;


    public Collider2D playerbox;
    bool ignore = true;
    void Start()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D playerbox) {
   //     if(!ignore){
            Application.LoadLevel("veoridesscene");
  //      }
 //       ignore = false;

    }
}
