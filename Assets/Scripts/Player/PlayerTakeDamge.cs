using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamge : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public bool isDeath;
    public GameObject Hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int damge)
    {
        Instantiate(Hit, rb.position, transform.rotation);
        FindObjectOfType<GameSession>().TakeLife(damge);
    }
    public void Death()
    {
        isDeath = true;
        rb.angularDrag = 10;
        rb.drag = 10;
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
