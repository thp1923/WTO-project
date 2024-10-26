using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rig;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpspeed = 30f;
    float currentSpeed;
    float currentJumpSpeed;
    CapsuleCollider2D col;
    Animator aim;
    public BoxCollider2D feet;
    public bool isAttack = false;

    public float dashBoots;
    public float dashTime;
    private float _dashTime;
    public bool isDashing;
    public int cost;

    public bool haveGround;

    public bool isCD;
    public float dashCD;
    float _dashCD;
    int stamina;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        aim = GetComponent<Animator>();
        currentJumpSpeed = jumpspeed;
        currentSpeed = speed;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            rig.velocity += new Vector2(0f, jumpspeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        Attack();
        Dash();
        stamina = FindObjectOfType<GameSession>().stamina;
    }
    void Dash()
    {
        _dashCD -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.E) && isCD == false && haveGround && stamina >= cost)
        {
            speed += dashBoots;
            _dashTime = dashTime;
            _dashCD = dashCD;
            isDashing = true;
            isCD = true;
            FindObjectOfType<GameSession>().CostStamina(cost);
            GetComponent<PlayerTakeDamge>().enabled = false;
        }

        if(isCD == true && _dashCD <= 0)
        {
            
            isCD = false;
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            speed -= dashBoots;
            isDashing = false ;
            GetComponent<PlayerTakeDamge>().enabled = true;
        }
        

        else
        {
            _dashTime -= Time.deltaTime;
        }
    }

    void Run()
    {
        rig.velocity = new Vector2(moveInput.x * speed, rig.velocity.y);

        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        aim.SetBool("Run", havemove);
        aim.SetFloat("Speed", speed);

        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            haveGround = true;
            aim.SetBool("Jump", false);
        }
        else
        {
            haveGround = false;
            aim.SetBool("Jump", true);
        }
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.J))
        {
            Stop();
        }
    }
    public void Stop()
    {
        aim.SetBool("Run", false );
        speed = 0;
        jumpspeed = 0;
    }
    public void Move()
    {
        isAttack = false;
        speed = currentSpeed;
        jumpspeed = currentJumpSpeed;
    }
    void Flip()
    {
        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;


        if (havemove)
        {

            transform.localScale = new Vector2(Mathf.Sign(rig.velocity.x), transform.localScale.y);
        }
        //RotatePlayer();

    }
}
