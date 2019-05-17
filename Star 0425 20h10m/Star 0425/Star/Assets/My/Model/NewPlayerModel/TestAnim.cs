using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour
{

    private Animator anim;
    public enum AnimNumber
    {
        MotionFloat, Damage,
        Left,Right,
    }
    AnimNumber animCount;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region 何もしていない時
        if (!Input.anyKey)
        {
            animCount = AnimNumber.MotionFloat;
            anim.SetBool("IsMotionFloat", true);
        }
        else anim.SetBool("IsMotionFloat", false);
        #endregion

        #region ダメージ時
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animCount = AnimNumber.Damage;
            anim.SetBool("IsDamage", true);
        }
        else anim.SetBool("IsDamage", false);
        #endregion


        #region 左向き開始
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (animCount != AnimNumber.Left) anim.SetBool("IsLeftStart", true);
            animCount = AnimNumber.Left;
        }
        else anim.SetBool("IsLeftStart", false);
        #endregion

        #region 左向き角度段階
        if (Input.GetKey(KeyCode.Alpha1))anim.SetBool("IsLeftFloat1", true);
        else anim.SetBool("IsLeftFloat1", false);

        if (Input.GetKey(KeyCode.Alpha2)) anim.SetBool("IsLeftFloat2", true);
        else anim.SetBool("IsLeftFloat2", false);

        if (Input.GetKey(KeyCode.Alpha3)) anim.SetBool("IsLeftFloat3", true);
        else anim.SetBool("IsLeftFloat3", false);
        #endregion


        #region 右向き開始
        if (Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.E))
        {
            if (animCount != AnimNumber.Right) anim.SetBool("IsRightStart", true);
            animCount = AnimNumber.Right;
        }
        else anim.SetBool("IsRightStart", false);
        #endregion

        #region 右向き角度段階
        if (Input.GetKey(KeyCode.Q)) anim.SetBool("IsRightFloat1", true);
        else anim.SetBool("IsRightFloat1", false);

        if (Input.GetKey(KeyCode.W)) anim.SetBool("IsRightFloat2", true);
        else anim.SetBool("IsRightFloat2", false);

        if (Input.GetKey(KeyCode.E)) anim.SetBool("IsRightFloat3", true);
        else anim.SetBool("IsRightFloat3", false);
        #endregion
    }
}
