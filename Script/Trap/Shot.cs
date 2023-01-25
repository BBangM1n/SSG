using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        Invoke("DestroyBulley", 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player Player = col.GetComponent<Player>();
            if(Player.godmode == 0){
                Player.Damaged(5);
                Player.OnDamaged(transform.position);
            }
            DestroyBulley();
        }

        if (col.CompareTag("Player2"))
        {
            Player2 Player2 = col.GetComponent<Player2>();
            if(Player2.godmode == 0){
                Player2.Damaged(5);
                Player2.OnDamaged(transform.position);
            }
            DestroyBulley();
        }
    }

    public void DestroyBulley()
    {
        Destroy(gameObject);
    }
}
