using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
}
