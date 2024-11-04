using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public GameObject nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void showNextScene()
    {
        nextScene.SetActive(true);
    }
}
