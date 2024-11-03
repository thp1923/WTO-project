using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject canva;
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
            canva.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(nextScene());
        }
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        FindObjectOfType<GameSession>().NextScene();
    }
}
