using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using System.Collections;
public class Controller : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Text pressAnyKeyText;
    public PlayableDirector timeline;
    private bool isWaitingForInput = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableAnyKey(4.5f));
    }
    IEnumerator EnableAnyKey(float delay)
    {
        yield return new WaitForSeconds(delay);
        isWaitingForInput = true;
        pressAnyKeyText.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isWaitingForInput)
        {
            if (Input.anyKeyDown)
            {
                timeline.Play();
                isWaitingForInput = false;
                pressAnyKeyText.enabled = false;
                Debug.Log("Enabling start button");
                playButton.gameObject.SetActive(true);
                Debug.Log("Enabling quit button");
                quitButton.gameObject.SetActive(true);
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
