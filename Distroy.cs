using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject playerObject = GameObject.Find("Player");
            Player Player = playerObject.GetComponent<Player>();

            Player.Damaged(100);
        }

        if(collision.gameObject.tag == "Player2")
        {
            GameObject playerObject2 = GameObject.Find("Player2");
            Player2 Player2 = playerObject2.GetComponent<Player2>();

            Player2.Damaged(100);
        }

    }
}
