using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRedbull : MonoBehaviour
{
    // Start is called before the first frame update
    public bool figure = false;
    private bool intialRedbullMove = true;
    float anglex;
    float angley;

    public Camera maincamera;
    void Start()
    {
        anglex = 0;
        angley = 0;
        maincamera.orthographicSize = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if(figure && intialRedbullMove) {
            intialRedbullMove = false;
            transform.Translate(new Vector3(-8, 6, 0));
        }

        if(figure) {

            transform.Translate(new Vector3(Mathf.Sin(anglex)*.5f,Mathf.Cos(angley)*.25f, 0 ));
            anglex += 0.05f;
            angley += 0.1f;
        }
        
    }
}
