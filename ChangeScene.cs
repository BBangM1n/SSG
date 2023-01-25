using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{   
    public void Login()
    {
            SceneManager.LoadScene("로그인화면");
    }
    public void register()
    {
            SceneManager.LoadScene("회원가입");
    }

    public void ChapChoice()
    {
        SceneManager.LoadScene("챕터선택화면");
    }

    public void CharChoice()
    {
        SceneManager.LoadScene("캐릭터 선택");
        Option.OptionPanel.SetActive(false);
    }

     public void chap1()
    {
        SceneManager.LoadScene("챕터1");
    }

    public void chapt2()
    {
        SceneManager.LoadScene("챕터2");
    }

    public void Rank()
    {
        SceneManager.LoadScene("랭킹");
    }

     public void GameQuit()
    {
           Application.Quit();
    }

    

    
}
