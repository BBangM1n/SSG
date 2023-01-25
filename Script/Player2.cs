using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player2 : MonoBehaviour
{
    public int PlayerNum;
    public float MaxHp = 100;
    public float CurHp = 100;
    float imsi;
    public int godmode = 0;

    public GameManager gameManager;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField]
    private Slider hpbar;
    [SerializeField]
    private float power;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    public float maxSpeed;
    float jumpCount = 2;
    public float jumpPower;
    public float playerDmg = 1;
    
    bool isGround;

    public GameObject UIBtn;
    public GameObject gum;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        imsi = (float) CurHp / (float) MaxHp;
    }

    private float curTime;
    public float coolTime = 0.5f;
    public Vector2 boxSize;
    public Transform pos2;

    private void Update()
    {
        //이동 & 모션
        if(Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.0001f, rigid.velocity.y);
            }

        if (Input.GetButtonDown("Jump") && jumpCount > 0){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            jumpCount--;
            } 

        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("moving", false);
        else
            anim.SetBool("moving", true);

        if(curTime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                gum.SetActive(true);
                anim.SetTrigger("ATK");
                curTime = coolTime;
                Invoke("Wait",0.1f);
            }
        }
        else{
            curTime -= Time.deltaTime;
        }

        imsi = (float) CurHp / (float) MaxHp;
        
        HandleHp();

        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("jump", false);
            jumpCount = 2;
        }
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * hor, ForceMode2D.Impulse);

        // 이동속도 최대값 
        if(rigid.velocity.x > maxSpeed)
           rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))
           rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

        
        if(hor > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (hor < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if(rigid.velocity.y < 0) {
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("ALLFloor"));

         if(rayHit.collider != null) {
             if(rayHit.distance < 0.5f){
                anim.SetBool("jump", false);
                jumpCount = 2; // 더블점프초기화
                }  
            }
        }
    }

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }

    // private void OnDrawGizmos()
    // { 
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireCube(pos2.position, boxSize);
    // }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damaged(5);
            OnDamaged(collision.transform.position);
        }

        if (collision.gameObject.tag == "Boss")
        {
            Damaged(10);
            OnDamaged(collision.transform.position);
        }
    }

    public void Damaged(float Dmg)
    {
        if(CurHp > 0)
        {
            CurHp -= Dmg;
        }
        else
        {
            CurHp = 0;
        }

        if(CurHp == 0)
        {
            Invoke("Restart",0.2f);
        }
    }

    public void OnDamaged(Vector2 targetPos)
    {
        godmode = 1;
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);//무적시간일 때 플레이어가 투명하게
        //한대 맞으면 튕겨나가게
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        //오른쪽으로 맞으면 오른쪽으로 튕겨나가고 왼쪽으로 맞으면 왼쪽으로 튕겨나가고
        rigid.AddForce(new Vector2(dirc, 1)*7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    public void OffDamaged()
    {
        godmode = 0;
        gameObject.layer = 9;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 10);
    }

    void Restart()
    {
        Time.timeScale = 0;
        Text btnText = UIBtn.GetComponentInChildren<Text>();
        btnText.text = "사망";
        UIBtn.SetActive(true);
    }

    void Wait()
    {
        gum.SetActive(false);
    }

}

