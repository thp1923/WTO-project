using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject UI;
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
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
