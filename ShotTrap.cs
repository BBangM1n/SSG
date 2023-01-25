using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTrap : MonoBehaviour
{
    public Transform pos;
    public GameObject bullet;
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
            Instantiate(bullet,pos.position,transform.rotation);
        }

        if (col.gameObject.tag == "Player2")
        {
            Instantiate(bullet,pos.position,transform.rotation);
        }


    }

}
