using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rank : MonoBehaviour
{
    public Text Ranktxt;
    string a = Userinfo.Rank1;

    void Start()
    {
        // Ranktxt;
        Debug.Log(Userinfo.Rank1);
        if(this.gameObject.name == "1등이름")
        {
            Ranktxt.text = Userinfo.Rank1;
        }   
        if(this.gameObject.name == "2등이름")
        {
            Ranktxt.text = Userinfo.Rank2;
        }   
        if(this.gameObject.name == "3등이름")
        {
            Ranktxt.text = Userinfo.Rank3;
        }    
    }
}
