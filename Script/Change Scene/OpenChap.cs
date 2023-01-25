using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChap : MonoBehaviour
{
    private GameObject Chap1Object;
    private GameObject Chap2Object;
    private GameObject Chap3Object;
    // Start is called before the first frame update
    void Start()
    {
        Chap1Object = GameObject.Find("1Chapter");
        Chap2Object = GameObject.Find("2Chapter");
        Chap3Object = GameObject.Find("3Chapter");
        if(Userinfo.UserScore == 1)
        {
            Chap2Object.SetActive(true);
        }
        else if(Userinfo.UserScore == 2)
        {
            Chap3Object.SetActive(true);
        }
    }
}
