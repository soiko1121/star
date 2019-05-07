using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    private Animator Anime;

    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) Anime.SetBool("IsRight", true);
        else Anime.SetBool("IsRight", false);

        if (Input.GetKey(KeyCode.A)) Anime.SetBool("IsLeft", true);
        else Anime.SetBool("IsLeft", false);

        if (Input.GetKey(KeyCode.Space)) Anime.SetBool("IsDamage", true);
        else Anime.SetBool("IsDamage", false);

        if (!Input.anyKey) Anime.SetBool("IsFloat", true);
        else Anime.SetBool("IsFloat", false);
    }
}
