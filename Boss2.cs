using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float Maxhp;
    public float Nowhp;
    public EnemyHP enemyhp;
    public int ptn;
    public int nextMove;
    public GameObject shot1;
    public GameObject shot2;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxcollider;

    public int Pnumber;
    private float cooltime;
    public GameObject portal;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    
    void Start()
    {
        Maxhp = 100;
        Nowhp = 100;
        enemyhp.SetHealth(Nowhp, Maxhp);
        cooltime = 0;
        ptn = 0;
    }
    void Update()
    {
        Pattern();
    }
    void Pattern()
    {
        if(Nowhp <= 99)
            shot1.SetActive(true);
        if(Nowhp <= 99)
            shot2.SetActive(true);
    }

    void Reload()
    {
        cooltime += Time.deltaTime;
    }

    public void Lastportal()
    {
        portal.SetActive(true);
    }


    public void die(float Dmg)
    {
        Nowhp -= Dmg;
        enemyhp.SetHealth(Nowhp, Maxhp);
        if(Nowhp <= 0)
        {
            onDamaged();
            Lastportal();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
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

        boxcollider.enabled = false;

        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        DeActive();
    }

    void DeActive()
    {
        Destroy(gameObject);
    }

}
