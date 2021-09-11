using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upmovie : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;

    public Transform t;
    public Camera mainCamera;
    float x =4;
    float y = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(0,10));
        
        
        t.localScale = new Vector3(x, y, 4);
        x += .046666666f;
        y += .046666666f;

    }
}
