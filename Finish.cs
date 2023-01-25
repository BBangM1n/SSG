using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // public EnemyCount Enemy;

    public GameManager gameManager;
    public GameObject[] Enemy;
    public int EnemyIndex;

    void Start()
    {
        EnemyIndex = Enemy.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Open();
        }
        if (col.gameObject.tag == "Player2")
        {
            Open2();
        }
    }

    void Open()
    {
        if(EnemyIndex == 0)
            gameManager.NextStage();
    }

    void Open2()
    {
        if(EnemyIndex == 0)
            gameManager.NextStage2();
    }

    public void Ecount()
    {
        EnemyIndex --;
    }
}
