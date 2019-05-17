using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    public Animator anime;
    private enum LR { left, right }
    private LR lr;
    public static float X
    {
        get; set;
    }
    public bool Hit
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        lr = LR.left;
        //anime.SetBool("IsFloat", true);
        //anime.SetBool("IsLeft", true);
    }
    private void Update()
    {
        //if (count < protectTime)
        //{
        //    count++;
        //}
        //else if (count == protectTime)
        //{
        //    model.GetComponent<MyAnimator>().anime.SetBool("IsDamage", false);
        //    model.GetComponent<MyAnimator>().anime.SetBool("IsFloat", true);
        //    Hit = false;
        //}
    }
    private void FixedUpdate()
    {
        Animation(X);
    }
    private void Animation(float x)
    {
        if (Hit)
        {
            anime.SetBool("IsDamage", true);
            anime.SetBool("IsLeft", false);
            anime.SetBool("IsRight", false);
            anime.SetBool("IsMotionFloat", false);
            anime.SetBool("IsDamage", true);
            Hit = false;
        }
        else if (!PlayerHit.Hit)
        {
            //anime.SetBool("IsFloat", true);
            //if (x > 0 && lr == LR.left)
            //{
            //    anime.SetBool("IsLeft", false);
            //    anime.SetBool("IsRight", true);
            //    lr = LR.right;
            //}
            //else if (x <= 0 && lr == LR.right)
            //{
            //    anime.SetBool("IsRight", false);
            //    anime.SetBool("IsLeft", true);
            //    lr = LR.left;
            //}
        }
    }
}
