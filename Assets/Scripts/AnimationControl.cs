using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    
   // public Animation walkAnimation;
  //  public AssetBundle jumpAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumping() {
        animator.SetBool("Jumping", true);
    }
    public void walking() {
        animator.SetBool("Jumping", false);
        animator.SetBool("Still", false);
    }
    public void idle() {
        animator.SetBool("Still", true);
        animator.SetBool("Jumping", false);
    }

}
