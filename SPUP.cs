using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPUP : MonoBehaviour
{
    public void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player Player = playerObject.GetComponent<Player>();

        Player.maxSpeed += 1.5f;

        DestroyObject();
    }

    public void RunItem2()
    {
        GameObject playerObject2 = GameObject.Find("Player2");
        Player2 Player2 = playerObject2.GetComponent<Player2>();

        Player2.maxSpeed += 1.5f;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
