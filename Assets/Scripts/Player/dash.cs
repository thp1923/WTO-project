using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float speed = 10;
    public float time = 2f;
    Rigidbody2D rig;
    public bool isDash;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isDash==false)
        {
            Dash();
        }
    }
    void Dash()
    {
        float DashDirection = transform.localScale.x;
        rig.velocity = new Vector2(DashDirection * speed, rig.velocity.y);
        isDash = true;
        Debug.Log(DashDirection);
        StartCoroutine(StopDash());
    }
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(time);
        rig.velocity = new Vector2(0, rig.velocity.y);
        isDash= false;
    }
}
