using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAttack.Instance.inputRecceived)
        {
            animator.SetTrigger("Attack1");
            PlayerAttack.Instance.InputManager();
            PlayerAttack.Instance.inputRecceived = false;
        }
    }
}
