using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBulley",2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Player")
            {
                GameObject playerObject = GameObject.Find("Player");
                Player Player = playerObject.GetComponent<Player>();
                Player.Damaged(5);
                Player.OnDamaged(transform.position);
            }
            if(ray.collider.tag == "Player2")
            {
                GameObject playerObject2 = GameObject.Find("Player2");
                Player2 Player2 = playerObject2.GetComponent<Player2>();
                Player2.Damaged(5);
                Player2.OnDamaged(transform.position);
            }
            DestroyBulley();
        }

            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        
    }

    public void DestroyBulley()
    {
        Destroy(gameObject);
    }
}

