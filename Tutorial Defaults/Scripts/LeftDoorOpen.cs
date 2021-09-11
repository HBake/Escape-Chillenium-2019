using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorOpen : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D playerbox;

    public Sprite graydoor;
    public SpriteRenderer rend;

    public SpriteRenderer revholder;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D playerbox) {
      //  rend.sprite = afteropen;
        rend.sprite = graydoor;
     //   rend.color = Color.gray;
        revholder.enabled = true;
    }
}
