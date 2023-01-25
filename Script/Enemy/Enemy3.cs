using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float Maxhp;
    public float Nowhp;
    public EnemyHP enemyhp;

    
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        Maxhp = 5;
        Nowhp = 5;
        enemyhp.SetHealth(Nowhp, Maxhp);
    }

    public void die(float Dmg)
    {
        Nowhp -= Dmg;
        enemyhp.SetHealth(Nowhp, Maxhp);
        if(Nowhp <= 0)
        {
            onDamaged();
            GameObject ec = GameObject.Find("Finish");
            Finish Finish = ec.GetComponent<Finish>();
            Finish.Ecount();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거됨");
        if(collision.gameObject.tag == "Attack")
        {
            GameObject playerObject = GameObject.Find("Player");
            Player Player = playerObject.GetComponent<Player>();
            bullet bullet = collision.gameObject.GetComponent<bullet>();

            die(Player.playerDmg);

            bullet.DestroyBulley();
        }

        if(collision.gameObject.tag == "Gum")
        {
            GameObject playerObject2 = GameObject.Find("Player2");
            Player2 Player2 = playerObject2.GetComponent<Player2>();

            die(Player2.playerDmg);
        }
    }

    public void onDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        spriteRenderer.flipY = true;

        capsulecollider.enabled = false;

        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Invoke("DeActive", 1);
    }

    void DeActive()
    {
        Destroy(gameObject);
    }
}

