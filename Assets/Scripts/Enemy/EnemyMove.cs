using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    Rigidbody2D rig;
    Animator aim;
    public float RunDistance = 30f;
    public float teleTime;
    public bool isTele;

    private bool isFlip = false;
    private Vector2 initialPosition;
    private float _teleTime;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rig = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRun();
        Flip();
        Debug.DrawRay(initialPosition, Vector2.right * RunDistance, Color.green);
        Debug.DrawRay(initialPosition, Vector2.left * RunDistance, Color.green);
    }
    void CheckRun()
    {

        var distance = Vector2.Distance(initialPosition,
                            target.position);
        if (distance < RunDistance)
        {
            _teleTime = teleTime;
            aim.SetBool("Run", true);
            isTele = false;
        }
        else
        {
            isTele = true;
            aim.SetBool("Run", false);
            agent.SetDestination(initialPosition);
            Tele();
        }
    }
    void Tele()
    {
        if (_teleTime <= 0 && isTele == true)
        {
            transform.position = initialPosition;
            isTele = false;
        }

        else
        {
            _teleTime -= Time.deltaTime;
        }
    }
    
    public void Run()
    {
        agent.SetDestination(target.position);
    }
    void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > target.position.x && isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
            
        }
        else if (transform.position.x < target.position.x && !isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
            
        }
    }
}
