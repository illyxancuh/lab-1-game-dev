using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSR;
    private Transform playerTf;
    private Animator playerAm;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jump;
    [SerializeField] Vector2 groundchecksize;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;
    private float move;
    private bool isjump;
    private bool onground;

    [Header("Configuration")]
    [SerializeField] private int maxHp;
    [SerializeField] private Slider hpslider;
    private int hp;

    [Header("Casting")]
    [SerializeField] private GameObject slime;
    [SerializeField] private Transform right;
    [SerializeField] private Transform left;
    [SerializeField] private float slimespeed;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAm = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
        playerTf = GetComponent<Transform>();
    }

    void Start()
    {
        hp = maxHp;
        hpslider.maxValue = maxHp;
        hpslider.value = hp;
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isjump = true;
        }
        playerAm.SetBool("Jump", isjump);
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            cast();
            playerAm.Play("rangeattack");
        }


        if (move != 0)
        {
            playerRb.velocity = new Vector2(move * speed, playerRb.velocity.y);
            playerAm.SetBool("IsMoving", true);
            if (move < 1)
            {
                playerSR.flipX = true;
            }
            else
            {
                playerSR.flipX = false;
            }
        }
        else
        {
            playerAm.SetBool("IsMoving", false);
        }

        if (isjump && onground)
        {
            playerRb.AddForce(Vector2.up * jump);
        }

        isjump = false;
        onground = Physics2D.OverlapBox(groundcheck.position, groundchecksize, 0, ground);
    }
    public void changeHp(int change)
    {
        hp += change;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp <= 0)
        {
            LevelManager.Instanse.Restart();
            Destroy(gameObject);
        }
        hpslider.value = hp;
    }

    private void cast()
    {
        GameObject slimeball1 = Instantiate(slime, right.position, Quaternion.identity);
        GameObject slimeball2 = Instantiate(slime, left.position, Quaternion.identity);
        changeHp(-10);
        slimeball1.GetComponent<Rigidbody2D>().velocity = Vector2.right * slimespeed;
        slimeball2.transform.Rotate(new Vector3(0, 0, 180));
        slimeball2.GetComponent<Rigidbody2D>().velocity = Vector2.left * slimespeed;
        Destroy(slimeball1, 5f);
        Destroy(slimeball2, 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundcheck.position, groundchecksize);
    }
}
