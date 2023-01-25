using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public GameObject[] Stages;
    public Player player;
    public Player2 player2;
    public static int PlayerNum;
    private GameObject player1Object;
    private GameObject player2Object;
    // Start is called before the first frame update
    void Start()
    {
        player1Object = GameObject.Find("Player");
        player2Object = GameObject.Find("Player2");
        if(Userinfo.CharNum == 1)
        {
            player2Object.SetActive(false);
        }
        else
        {
            player1Object.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    //다음 스테이지
    public void NextStage()
    {
        if(stageIndex < Stages.Length -1){
        Stages[stageIndex].SetActive(false);
        stageIndex ++;
        Stages[stageIndex].SetActive(true);
        Playerposition();
        }
    }

    //플레이어 포지션 초기화
    void Playerposition()
    {
        player.transform.position = new Vector3(0, 0, 0);
        player.VelocityZero();
    }

    public void NextStage2()
    {
        if(stageIndex < Stages.Length -1){
        Stages[stageIndex].SetActive(false);
        stageIndex ++;
        Stages[stageIndex].SetActive(true);
        Playerposition2();
        }
    }

    void Playerposition2()
    {
        player2.transform.position = new Vector3(0, 0, 0);
        player2.VelocityZero();
    }

    //플레이어 게임 다시 시작 기능
    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}
