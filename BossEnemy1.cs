using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy1 : MonoBehaviour
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

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        Invoke("Think", 5);
    }

    void Start()
    {
        Maxhp = 5;
        Nowhp = 5;
        enemyhp.SetHealth(Nowhp, Maxhp);
        mydmg = 5;
    }

    public void die(float Dmg)
    {
        Nowhp -= Dmg;
        enemyhp.SetHealth(Nowhp, Maxhp);
        if(Nowhp <= 0)
        {
            onDamaged();
        }
    }
    // 프리팹 화 한거는 꺼두기

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

    void FixedUpdate()
    {
        //움직임
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //플랫폼 체크
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ALLFloor"));

         if(rayHit.collider == null) {
            turn();
         }
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

