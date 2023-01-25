using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float Maxhp;
    public float Nowhp;
    public EnemyHP enemyhp;
    
    public int mydmg;
    public float nextMove;
    string dist = "";

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;

    public float movePower = 1f;
    Vector3 moveVelocity = Vector3.zero;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing = false;
    GameObject traceTarget;

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
        mydmg = 5;

        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
            anim.SetBool("EnemyRun", false);
        else    
            anim.SetBool("EnemyRun", true);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }


    void Move()
    {

        if(isTracing){
            Vector3 playerPos = traceTarget.transform.position;

            if(playerPos.x < transform.position.x)
                dist = "Left";
            else if(playerPos.x > transform.position.x)
                dist = "Right";
        }
        else{
            if(movementFlag == 1)
                dist = "Left";
            else if(movementFlag == 2)
                dist = "Right";
        }

        if(dist == "Left"){
            nextMove = -1;
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(dist == "Right"){
            nextMove = 1;
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove,rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ALLFloor"));

        if(rayHit.collider == null)
        {
            if(nextMove == -1){
                transform.position += Vector3.right * movePower * Time.deltaTime;
            }
            else if(nextMove == 1){
                transform.position += Vector3.left * movePower * Time.deltaTime;
            }
        }
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

        
        if (collision.gameObject.tag == "PlayerPos"){
            traceTarget = collision.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerPos"){
            movePower = 2f;
            isTracing = true;
            anim.SetBool("EnemyFastRun", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerPos"){
            movePower = 1f;
            isTracing = false;
            anim.SetBool("EnemyFastRun", false);
            StartCoroutine("ChangeMovement");
        }
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

}