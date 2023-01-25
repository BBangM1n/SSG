using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itembox : MonoBehaviour
{
    public GameObject[] item;
    public int itemnum;
    public int max = 0;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void itembox()
    {
        itemnum = Random.Range(0, 4);
        Vector2 vec = new Vector2(transform.position.x, transform.position.y + 2);
        Instantiate(item[itemnum],vec,transform.rotation);
        max = 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(max == 0)
                itembox();
                anim.SetBool("Open", true);
                Invoke("DeActive", 2);
        }

        if (collision.gameObject.tag == "Player2")
        {
            if(max == 0)
                itembox();
                anim.SetBool("Open", true);
                Invoke("DeActive", 2);
        }
    }

    void DeActive()
    {
        Destroy(gameObject);
    }
}
