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
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        lr = LR.left;
        anime.SetBool("IsLeft", true);
    }
    private void FixedUpdate()
    {
        Animation(X);
    }
    private void Animation(float x)
    {
        if (x > 0 && lr == LR.left)
        {
            anime.SetBool("IsLeft", false);
            anime.SetBool("IsRight", true);
            lr = LR.right;
        }
        else if (x <= 0 && lr == LR.right)
        {
            anime.SetBool("IsRight", false);
            anime.SetBool("IsLeft", true);
            lr = LR.left;
        }
    }
}
