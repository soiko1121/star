using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToCon : MonoBehaviour
{
    public GameObject howTo;
    public GameObject other;
    public GameObject[] HTpre;

    private GameObject HTobj;
    private int selsectNum = 0;

    public void StartHowTo()
    {
        Debug.Log(1);
        howTo.SetActive(true);
        other.SetActive(false);
        HTobj = Instantiate(HTpre[0], howTo.transform);
        HTobj.transform.SetSiblingIndex(2);
    }
    public void endHowTo()
    {
        Destroy(HTobj);
        howTo.SetActive(false);
        other.SetActive(true);
    }

    public void changeRightHT()
    {
        Destroy(HTobj);
        selsectNum++;
        if (selsectNum >= HTpre.Length)
        {
            selsectNum = 0;
        }
        HTobj = Instantiate(HTpre[selsectNum], howTo.transform);
        HTobj.transform.SetSiblingIndex(2);
    }
    public void changeLeftHT()
    {
        Destroy(HTobj);
        selsectNum--;
        if (selsectNum <= 0)
        {
            selsectNum = HTpre.Length - 1;
        }
        HTobj = Instantiate(HTpre[selsectNum], howTo.transform);
        HTobj.transform.SetSiblingIndex(2);
    }
}
