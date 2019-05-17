using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    public Animator anim;
    //private enum LR { left, right, no }
    //private LR lr;
    public static float X
    {
        get; set;
    }
    public bool Hit
    {
        get; set;
    }

    public enum AnimNumber
    {
        MotionFloat, Damage,
        Left, Right,
    }
    AnimNumber animCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Hit = false;
        //lr = LR.left;
        //anim.SetBool("IsMotionFloat", true);
        //anime.SetBool("IsFloat", true);
        //anime.SetBool("IsLeft", true);
    }
    private void Update()
    {
        Animation(X);
    }
    private void FixedUpdate()
    {
    }
    private void Animation(float x)
    {
        if (Hit)
        {
            anim.SetBool("IsDamage", true);
            //anime.SetBool("IsLeftStart", false);
            //anime.SetBool("IsRightStart", false);
            //anime.SetBool("IsMotionFloat", false);
            Hit = false;
        }
        else if (!PlayerHit.Hit)
        {
            anim.SetBool("IsDamage", false);
            #region 何もしていない時
            if (x == 0)
            {
                animCount = AnimNumber.MotionFloat;
                anim.SetBool("IsMotionFloat", true);
            }
            else anim.SetBool("IsMotionFloat", false);
            #endregion


            #region 左向き開始
            if (x < 0)
            {
                if (animCount != AnimNumber.Left) anim.SetBool("IsLeftStart", true);
                else anim.SetBool("IsLeftStart", false);
                animCount = AnimNumber.Left;
            }
            else anim.SetBool("IsLeftStart", false);
            #endregion

            #region 左向き角度段階
            if (x < -1f) anim.SetBool("IsLeftFloat1", true);
            else anim.SetBool("IsLeftFloat1", false);

            if (x < -0.5f && x > -1f) anim.SetBool("IsLeftFloat2", true);
            else anim.SetBool("IsLeftFloat2", false);

            if (x < 0 && x > -0.5f) anim.SetBool("IsLeftFloat3", true);
            else anim.SetBool("IsLeftFloat3", false);
            #endregion


            #region 右向き開始
            if (x > 0)
            {
                if (animCount != AnimNumber.Right) anim.SetBool("IsRightStart", true);
                else anim.SetBool("IsRightStart", false);
                animCount = AnimNumber.Right;
            }
            else anim.SetBool("IsRightStart", false);
            #endregion

            #region 右向き角度段階
            if (x > 1f) anim.SetBool("IsRightFloat1", true);
            else anim.SetBool("IsRightFloat1", false);

            if (x > 0.5f && x < 1f) anim.SetBool("IsRightFloat2", true);
            else anim.SetBool("IsRightFloat2", false);

            if (x > 0 && x < 0.5f) anim.SetBool("IsRightFloat3", true);
            else anim.SetBool("IsRightFloat3", false);
            #endregion



            #region
            //anime.SetBool("IsDamage", false);
            //if (x < 0)
            //{
            //    anime.SetBool("IsMotionFloat", false);
            //    anime.SetBool("IsRightStart", false);
            //    anime.SetBool("IsRightFloat1", false);
            //    anime.SetBool("IsRightFloat2", false);
            //    anime.SetBool("IsRightFloat3", false);
            //    if (lr != LR.left)
            //    {
            //        anime.SetBool("IsLeftStart", true);
            //        lr = LR.left;
            //    }
            //    else
            //        anime.SetBool("IsLeftStart", false);

            //    if (x < -1f)
            //    {
            //        anime.SetBool("IsLeftFloat1", false);
            //        anime.SetBool("IsLeftFloat2", false);
            //        anime.SetBool("IsLeftFloat3", true);
            //    }
            //    else if (x < -0.5f)
            //    {
            //        anime.SetBool("IsLeftFloat1", false);
            //        anime.SetBool("IsLeftFloat3", false);
            //        anime.SetBool("IsLeftFloat2", true);
            //    }
            //    else if (x < 0)
            //    {
            //        anime.SetBool("IsLeftFloat2", false);
            //        anime.SetBool("IsLeftFloat3", false);
            //        anime.SetBool("IsLeftFloat1", true);
            //    }
            //}
            //else if (x > 0)
            //{
            //    anime.SetBool("IsMotionFloat", false);
            //    anime.SetBool("IsLeftStart", false);
            //    anime.SetBool("IsLeftFloat1", false);
            //    anime.SetBool("IsLeftFloat2", false);
            //    anime.SetBool("IsLeftFloat3", false);
            //    if (lr != LR.right)
            //    {
            //        anime.SetBool("IsRightStart", true);
            //        lr = LR.right;
            //    }
            //    else
            //        anime.SetBool("IsRightStart", false);

            //    if (x > 1f)
            //    {
            //        anime.SetBool("IsRightFloat1", false);
            //        anime.SetBool("IsRightFloat2", false);
            //        anime.SetBool("IsRightFloat3", true);
            //    }
            //    else if (x > 0.5f)
            //    {
            //        anime.SetBool("IsRightFloat1", false);
            //        anime.SetBool("IsRightFloat3", false);
            //        anime.SetBool("IsRightFloat2", true);
            //    }
            //    else if (x > 0)
            //    {
            //        anime.SetBool("IsRightFloat2", false);
            //        anime.SetBool("IsRightFloat3", false);
            //        anime.SetBool("IsRightFloat1", true);
            //    }
            //}
            //else
            //{
            //    anime.SetBool("IsMotionFloat", true);
            //    lr = LR.no;
            //}
            #endregion
        }
    }
}
