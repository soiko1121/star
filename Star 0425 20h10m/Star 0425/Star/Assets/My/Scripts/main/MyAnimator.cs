using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    public Animator anim;
    public PlayerMove Max;

    float leftMin, leftMax;
    float righMin, righMax;

    int countTime;

    public float X
    {
        get; set;
    }
    public float PM
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
        Default
    }
    AnimNumber animCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsMotionFloat", true);
        Hit = false;

        //最大値を3で割った数値
        righMin = Max.maxAcceleration.x / 3;
        righMax = righMin + righMin;
        leftMin = -righMin;
        leftMax = -righMax;
    }

    private void Update()
    {
        #region ダメージ時
        if (PlayerHit.Hit)
        {
            countTime++;        //モーションが再生し終わるタイミングのための計測

            if (animCount != AnimNumber.Damage)
            {
                anim.SetBool("IsMotionFloat", false);
                anim.SetBool("IsDamage", true);
                animCount = AnimNumber.Damage;
            }
            else
            {
                //30待つ
                if (countTime >= 25)
                {
                    countTime = 0;
                    PlayerHit.Hit = false;
                }
            }
        }
        #endregion
        else
        {
            anim.SetBool("IsDamage", false);

            if (X * PM < 0 || X * PM > 0)
            {
                Animation(X * PM);
            }
            else
            {
                //何もしていないとき
                anim.SetBool("IsRightFloat1", false);
                anim.SetBool("IsRightFloat2", false);
                anim.SetBool("IsRightFloat3", false);
                anim.SetBool("IsLeftFloat1", false);
                anim.SetBool("IsLeftFloat2", false);
                anim.SetBool("IsLeftFloat3", false);

                anim.SetBool("IsMotionFloat", true);

                animCount = AnimNumber.Default;
            }
        }

    }

    private void Animation(float x)
    {
        anim.SetBool("IsMotionFloat", false);

        #region 何もしていない時
        if (x == 0)
        {
            if (animCount != AnimNumber.MotionFloat) anim.SetBool("IsMotionFloat", true);
            else anim.SetBool("IsMotionFloat", false);
            animCount = AnimNumber.MotionFloat;
        }
        else anim.SetBool("IsMotionFloat", false);
        #endregion


        #region 左向き開始
        if (x < 0)
        {
            anim.SetBool("IsRightFloat1", false);
            anim.SetBool("IsRightFloat2", false);
            anim.SetBool("IsRightFloat3", false);

            //斜め処理
            if (x < 0 && x > leftMin) anim.SetBool("IsLeftFloat1", true);
            else anim.SetBool("IsLeftFloat1", false);

            if (x <= leftMin && x > leftMax) anim.SetBool("IsLeftFloat2", true);
            else anim.SetBool("IsLeftFloat2", false);

            if (x <= leftMax) anim.SetBool("IsLeftFloat3", true);
            else anim.SetBool("IsLeftFloat3", false);
        }
        #endregion


        #region 右向き開始
        if (x > 0)
        {
            anim.SetBool("IsLeftFloat1", false);
            anim.SetBool("IsLeftFloat2", false);
            anim.SetBool("IsLeftFloat3", false);

            //斜め処理
            if (x > 0 && x < righMin) anim.SetBool("IsRightFloat1", true);
            else anim.SetBool("IsRightFloat1", false);

            if (x >= righMin && x < righMax) anim.SetBool("IsRightFloat2", true);
            else anim.SetBool("IsRightFloat2", false);

            if (x >= righMax) anim.SetBool("IsRightFloat3", true);
            else anim.SetBool("IsRightFloat3", false);
        }
        #endregion

    }
}
