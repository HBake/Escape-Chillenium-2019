using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRedbullFly : MonoBehaviour
{
       // Start is called before the first frame update
    public bool figure = false;
    private bool intialRedbullMove = true;
    float anglex;
    float angley;

    float angleyplus = .1f;
    float anglexplus = .05f;
    float xmult = .5f;
    float ymult = .25f;
    public Rigidbody2D rb;
    public Rigidbody2D Player;

    float camyless = 0;

    bool cam = true;

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
        if(cam){
            maincamera.transform.position = new Vector2(Player.position.x, Player.position.y + 1);
            maincamera.orthographicSize += 0.02f;
            transform.Translate(new Vector3(Mathf.Sin(anglex)*xmult,Mathf.Cos(angley)*ymult, 0 ));
        }
        else {
            maincamera.transform.position = new Vector2(Player.position.x, Player.position.y + 1 - camyless);
            camyless += 1;
            if(camyless >= 50) {
                Application.LoadLevel("gamer");
            }
        }

        if(figure && intialRedbullMove) {
            intialRedbullMove = false;
            transform.Translate(new Vector3(-8, 6, 0));
        }

        if(figure) {

            
            anglex += anglexplus;
            angley += angleyplus;
            anglexplus -= .00005f;
            angleyplus -= .0001f;
            xmult += .0005f;
            ymult += .00025f;
         //   Debug.Log(xmult);
         //   Debug.Log(ymult);
          //  Debug.Log(angleyplus);
         //   Debug.Log(anglexplus);

            if(xmult >= 0.89) {
                cam = false;
            }

            rb.AddForce(new Vector2(0,6));


        }
        
    }
}