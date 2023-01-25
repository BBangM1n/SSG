using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player Player = playerObject.GetComponent<Player>();
        

        Player.CurHp += 30;
        if(Player.CurHp > 100)
        {
            Player.CurHp = 100;
        }
        DestroyObject();
    }

    public void RunItem2()
    {
        GameObject playerObject2 = GameObject.Find("Player2");
        Player2 Player2 = playerObject2.GetComponent<Player2>();
        

        Player2.CurHp += 30;
        if(Player2.CurHp > 100)
        {
            Player2.CurHp = 100;
        }
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            RunItem();
        }
        if(col.gameObject.CompareTag("Player2"))
        {
            RunItem2();
        }
    }
}
