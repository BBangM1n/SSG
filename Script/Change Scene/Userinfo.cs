using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userinfo : MonoBehaviour
{
    public static string userinfoID;
    public static string Rank1;
    public static string Rank2;
    public static string Rank3;
    public static int CharNum = 0;
    public static int ChapNum = 0;
    public static int UserScore = 0;
    public static int something = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Text userinfoID = GameObject.Find("아이디입력").GetComponentInChildren<Text>();
        // if(userinfoID.text == "1234")
        // {
        //     Debug.Log("correct");
        // }
        // else
        // {
        //     Debug.Log("null");
        // }
        
    }
    void Update()
    {
        Ranking();
    }
    
    public void Ranking()
    {
        StartCoroutine(LoadRank());
    }

    IEnumerator LoadRank()
    { 
        string RankURL = "http://52.79.139.236/Ranking.php";
        WWW www = new WWW(RankURL);
        yield return www;

        string[] split_text = www.text.Split(",");
        Userinfo.Rank1 = split_text[0];
        Userinfo.Rank2 = split_text[1];
        Userinfo.Rank3 = split_text[2];
    }

    IEnumerator User_Score()
    { 
        string RankURL = "http://52.79.139.236/Ranking.php";
        WWW www = new WWW(RankURL);
        yield return www;
    }


}
