using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public GameObject Hit;
    public GameObject damPopUp;
    public GameObject enemyStun;

    public int Def;
    public float stunTime;
    
    public bool isDeath;
    public bool haveParry;

    public float parryCD;
    float _parryCD;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Def = FindObjectOfType<GameSession>().Def;
        Parry();
    }
    public void TakeDamge(int damge, float SkillDamge, float knockBack, float knockBackUp)
    {
        if(haveParry == true)
        {
            FindObjectOfType<EnemyTakeDamge>().Stun();
            CameraShake.Instance.ShakeCamera(5f, 0.1f);
            enemyStun.SetActive(true);
            Invoke(nameof(StunEnd), stunTime);
            
        }
        if (isDeath == false && haveParry == false)
        {
            audioManager.playSFX(audioManager.Hit);
            int HPlost = (int)(damge+(SkillDamge/Def)*3);
            Instantiate(Hit, rb.position, transform.rotation);
            FindObjectOfType<GameSession>().TakeLife(HPlost);
            rb.AddForce(transform.up * knockBackUp, ForceMode2D.Impulse);
            GameObject instance = Instantiate(damPopUp, transform.position
            + new Vector3(UnityEngine.Random.Range(-0.7f, 0.7f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = HPlost.ToString();
            Animator aim = instance.GetComponentInChildren<Animator>();
            animator.SetTrigger("Hit");

            if (transform.localScale.x < 0)
            {

                rb.AddForce(transform.right * knockBack, ForceMode2D.Impulse);
            }
            else if (transform.localScale.x > 0)
            {

                rb.AddForce(transform.right * -knockBack, ForceMode2D.Impulse);
            }
        }
    }
    public void ParryEnd()
    {
        haveParry = false;
        FindObjectOfType<PlayerMove>().Move();
    }
    public void StunEnd()
    {
        enemyStun.SetActive(false);
        FindObjectOfType<EnemyTakeDamge>().StunEnd();
    }
    void Parry()
    {
        _parryCD -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.R) && _parryCD <= 0)
        {
            animator.SetTrigger("Parry");
            haveParry = true;
            _parryCD = parryCD;
            audioManager.playSFX(audioManager.Parry);
            FindObjectOfType<PlayerMove>().Stop();
        }
    }
    public void FlipTakeDamge(bool flip)
    {
        if (flip == true)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);


        }
        else if (flip == false)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);

        }
    }
    public void Death()
    {
        animator.SetBool("Death", true);
        isDeath = true;
        rb.angularDrag = 10;
        rb.drag = 10;
        audioManager.playSFX(audioManager.Death);
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
