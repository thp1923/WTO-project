using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // nếu khoảng cách của nhân vật và quái
        // nhỏ hơn 10 thì quái sẽ di chuyển đến
        // vị trí của nhân vật
        // sau khi nhân vật ra khỏi phạm vi 10
        // quái quay về vị trí ban đầu
        var distance = Vector3.Distance(initialPosition, 
                            target.position);
        if(distance< 10)
            agent.SetDestination(target.position);
        else
        {
            agent.SetDestination(initialPosition);
        }
        
        // đi lang thang
        var randomPosition = new Vector3(
            Random.Range(-10, 10),
            Random.Range(-10, 10),
            0
        );
        // chạy trốn
    }
}
