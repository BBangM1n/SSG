using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotbullet : MonoBehaviour
{
    public Transform pos;
    public GameObject bullet;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Shot()
    {
        Instantiate(bullet,pos.position,transform.rotation);
    }
}
