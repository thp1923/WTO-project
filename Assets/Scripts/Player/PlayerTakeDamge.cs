using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public bool isDeath;
    public GameObject Hit;
    public int Def;

    public bool NoTakeDamge;
    public GameObject damPopUp;
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
    }
    public void TakeDamge(int damge, float SkillDamge, float knockBack, float knockBackUp)
    {
        if (isDeath == false)
        {
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
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
