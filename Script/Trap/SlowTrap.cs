using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player Player = col.GetComponent<Player>();
            if(Player.maxSpeed == 5f)
            {
                
                Player.maxSpeed -= 1.5f;
                Invoke("clear", 10f);
            }
        }

        if (col.gameObject.tag == "Player2")
        {
            Player2 Player2 = col.GetComponent<Player2>();
            if(Player2.maxSpeed == 5f)
            {
                
                Player2.maxSpeed -= 1.5f;
                Invoke("clear2", 10f);
            }
        }

    }

    public void clear()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player Player = playerObject.GetComponent<Player>();
        Player.maxSpeed += 1.5f;
    }

    public void clear2()
    {
        GameObject playerObject2 = GameObject.Find("Player2");
        Player2 Player2 = playerObject2.GetComponent<Player2>();
        Player2.maxSpeed += 1.5f;
    }

}
