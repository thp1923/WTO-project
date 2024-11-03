using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}