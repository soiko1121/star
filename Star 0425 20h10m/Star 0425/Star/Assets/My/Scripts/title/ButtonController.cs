using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    Image img;
    Image upImg;

    [SerializeField]
    Sprite downImg;

    [SerializeField]
    GameObject startUI;

    [SerializeField]
    GameObject menuUI;

    private void Start()
    {
        img = GetComponent<Image>();
        upImg = img;
    }

    public void ButtonDown()
    {
        img.sprite = downImg;
    }

    public void ButtonUp()
    {
        img.sprite = upImg.sprite;
        Resources.UnloadUnusedAssets();//一回全部消し飛ばすやつ　by亀
        SceneManager.LoadScene("SelectScene");
    }
}
