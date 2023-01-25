using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextScript : MonoBehaviour
{ 
    public Text Ranktxt;

    void Start()
    { 
        string a = Userinfo.Rank1;
        Ranktxt.text = Userinfo.Rank1;
    }
}
