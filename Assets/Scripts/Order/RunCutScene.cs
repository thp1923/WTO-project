using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCutScene : MonoBehaviour
{
    BoxCollider2D col;
    public GameObject cutScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            cutScene.SetActive(true);
    }
}
