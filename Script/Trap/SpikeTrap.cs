using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
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
        if (col.CompareTag("Player"))
        {
            Player Player = col.GetComponent<Player>();
            if(Player.godmode == 0)
            {
                Player.Damaged(1);
                Player.OnDamaged(col.transform.position);
            }
        }

        if (col.CompareTag("Player2"))
        {
            Player2 Player2 = col.GetComponent<Player2>();
            if(Player2.godmode == 0)
            {
                Player2.Damaged(1);
                Player2.OnDamaged(col.transform.position);
            }
        }
    }
}
