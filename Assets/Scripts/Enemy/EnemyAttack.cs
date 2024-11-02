using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Animator aim;
    Rigidbody2D rig;
    Transform target;

    public int BaseAttack;
    public Vector2 AttackRange;
    public Transform AttackPoint;
    public LayerMask playerLayer;

    public float AttackDamge1;

    public float knockBack = 5f;
    public float knockBackUp = 1f;

    public float attackRange;

    float Damge;
    bool isFlip;

    bool haveParry;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        aim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        haveParry = FindObjectOfType<PlayerTakeDamge>().haveParry;
        if(FindObjectOfType<PlayerTakeDamge>().isDeath == true)
        {
            return;
        }
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isFlip = GetComponent<EnemyMove>().isFlip;
        Debug.DrawRay(rig.position, Vector2.right * attackRange, Color.red);
        Debug.DrawRay(rig.position, Vector2.left * attackRange, Color.red);
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            aim.SetTrigger("Attack1");
            aim.SetBool("Run", false);
            GetComponent<EnemyMove>().enabled = false;
        }
        else 
        {
            GetComponent<EnemyMove>().enabled = true;
            return;
        }
    }

    public void Attack1()
    {
        Damge = BaseAttack * AttackDamge1;
        Attack();
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(AttackPoint.position, AttackRange, 1, playerLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (haveParry)
            {
                CameraShake.Instance.ShakeCamera(5f, 0.1f);
                Stun();
                return;
            }
            FindObjectOfType<PlayerTakeDamge>().FlipTakeDamge(isFlip);
            enemy.GetComponent<PlayerTakeDamge>().TakeDamge(BaseAttack, Damge, knockBack, knockBackUp);
        }
    }
    public void Stun()
    {
        aim.SetBool("Stun", true);
        aim.SetTrigger("Hit");
        aim.SetBool("Run", false);
        audioManager.playSFX(audioManager.ParryEnemy);
        Invoke(nameof(StunEnd), 2);

    }
    public void StunEnd()
    {
        aim.SetBool("Stun", false);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPoint.position, AttackRange);

    }
}
