using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public float changeTime;
    public string sceneName;
    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
