using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    public void Char1()
    {
            Userinfo.CharNum = 1;
            SceneManager.LoadScene("챕터선택화면");
    }

    public void Char2()
    {       
            Userinfo.CharNum = 2;
            SceneManager.LoadScene("챕터선택화면");
    }

    public void Chapter1()
    {
            Userinfo.ChapNum = 1;  
        // Chap1 = GameObject.Find("챕터1");
        // if(Userinfo.CharNum == 1)
        // {
        //    Chap1.Player.SetActive(True);  
        // }
        // else
        // {
        //     Chap1.Player2.SetActive(True); 
        // }
            SceneManager.LoadScene("챕터1");
    }

    public void Chapter2()
    {
            Userinfo.ChapNum = 2;
        // Chap2 = GameObject.Find("챕터2");
        // if(Userinfo.CharNum == 1)
        // {
        //    Chap2.Player.SetActive(True);  
        // }
        // else
        // {
        //     Chap2.Player2.SetActive(True); 
        // }
        SceneManager.LoadScene("챕터2");
    }
    
}
