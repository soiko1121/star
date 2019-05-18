using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    public Animator anim;

    public float LeftMax = -1f;         //左の3段階目の傾き実行値
    public float LeftNormal = -0.5f;    //左の2段階目の傾き実行値
    public float LeftMin = 0f;          //左のモーションを実行する値

    public float RightMax = 1f;         //右の3段階目の傾き実行値
    public float RightNormal = 0.5f;    //右の2段階目の傾き実行値
    public float RightMin = 0f;         //右のモーションを実行する値

    public float X
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
    }

    private void Update()
    {
        Animation(X);
    }

    private void Animation(float x)
    {
        if (Hit)
        {
            anim.SetBool("IsDamage", true);
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
            if (x < LeftMin)
            {
                if (animCount != AnimNumber.Left) anim.SetBool("IsLeftStart", true);
                else anim.SetBool("IsLeftStart", false);
                animCount = AnimNumber.Left;
            }
            else anim.SetBool("IsLeftStart", false);
            #endregion

            #region 左向き角度段階
            if (x < LeftMin && x >= LeftNormal) anim.SetBool("IsLeftFloat1", true);
            else anim.SetBool("IsLeftFloat1", false);

            if (x < LeftNormal && x >= LeftMax) anim.SetBool("IsLeftFloat2", true);
            else anim.SetBool("IsLeftFloat2", false);

            if (x < LeftMax) anim.SetBool("IsLeftFloat3", true);
            else anim.SetBool("IsLeftFloat3", false);
            #endregion


            #region 右向き開始
            if (x > RightMin)
            {
                if (animCount != AnimNumber.Right) anim.SetBool("IsRightStart", true);
                else anim.SetBool("IsRightStart", false);
                animCount = AnimNumber.Right;
            }
            else anim.SetBool("IsRightStart", false);
            #endregion

            #region 右向き角度段階
            if (x > RightMin && x <= RightNormal) anim.SetBool("IsRightFloat1", true);
            else anim.SetBool("IsRightFloat1", false);

            if (x > RightNormal && x <= RightMax) anim.SetBool("IsRightFloat2", true);
            else anim.SetBool("IsRightFloat2", false);

            if (x > RightMax) anim.SetBool("IsRightFloat3", true);
            else anim.SetBool("IsRightFloat3", false);
            #endregion
        }
    }
}
