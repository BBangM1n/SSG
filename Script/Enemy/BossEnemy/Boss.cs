using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float Maxhp;
    public float Nowhp;
    public EnemyHP enemyhp;
    public int nextMove;
    public int mydmg;
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;

    public int Pnumber;
    public GameObject[] Enemy;
    private float cooltime;
    public GameObject portal;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        Invoke("Think", 7);
    }
    
    void Start()
    {
        Maxhp = 100;
        Nowhp = 100;
        enemyhp.SetHealth(Nowhp, Maxhp);
        mydmg = 5;
        cooltime = 0;
    }

    void Update()
    {
        Reload();
        if(cooltime > 5)
        {
            Pattern();
            cooltime = 0;
        }
    }

    void Pattern()
    {
        Pnumber = Random.Range(0, 4);

        Instantiate(Enemy[Pnumber],transform.position,transform.rotation);

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

    void FixedUpdate()
    {
         //움직임
        rigid.velocity = new Vector2(nextMove * 3f, rigid.velocity.y);

        // //플랫폼 체크
        // Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.5f, rigid.position.y);
        // Debug.DrawRay(frontVec, Vector3.down * 2.5f , new Color(0, 1, 0));
 
        // RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down * 2.5f, 1, LayerMask.GetMask("ALLFloor"));

        //  if(rayHit.collider == null) {
        //     turn();
        //  }
    }

    void Think()
    {
        //방향 선택
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
        //걷기모션
        anim.SetInteger("EnemyRun", nextMove);

        //방향전환
        if(nextMove != 0)
           spriteRenderer.flipX = nextMove == 1;
    }

    public void onDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        spriteRenderer.flipY = true;

        capsulecollider.enabled = false;

        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Invoke("DeActive", 3);
    }

    void DeActive()
    {
        Destroy(gameObject);
    }

    void turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 5);
    }

}
