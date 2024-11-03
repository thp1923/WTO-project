using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class False : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Removed();
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameSession>().False();
    }
    void Removed()
    {
        Destroy(gameObject, 6);
    }
}
