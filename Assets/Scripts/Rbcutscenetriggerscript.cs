using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rbcutscenetriggerscript : MonoBehaviour

{
    // Start is called before the first frame update


    public Collider2D playerbox;
    public FlyingRedbull frb;
    public Camera maincamera;
    void Start()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D playerbox) {
        //Application.LoadLevel("spook");
  //      Debug.Log("gamer");
        
  //      frb.figure = true;

        maincamera.orthographicSize = 10;


    }
}
