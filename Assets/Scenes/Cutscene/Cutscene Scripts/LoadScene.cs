using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameSession>().NextScene();
    }
    void Update()
    {

    }
}