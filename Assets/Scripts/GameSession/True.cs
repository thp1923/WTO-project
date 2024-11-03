using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class True : MonoBehaviour
{
    void Start()
    {
        Removed();
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameSession>().True();
    }
    void Removed()
    {
        Destroy(gameObject, 6);
    }
}
