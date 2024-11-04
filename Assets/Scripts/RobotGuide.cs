using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RobotGuide : MonoBehaviour
{
    public GameObject panel;
    public Text dialogueText;
    public string[] dialogue;
    public string[] AlternativeDialogue;
    private bool useAlternativeDialogue = false;
    private int index;
    public float timeNext = 1f;
    float nextTime;
    public GameObject nextButton;
    public float wordSpeed;
    public bool playerIsClose;
    public Animator animator;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(nextLine);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose == true && Time.time >= nextTime)
        {
            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
                animator.SetBool("IsTalking", false);
            }
            else
            {
                panel.SetActive(true);
                animator.SetBool("IsTalking", true);
                StartCoroutine(Typing());
            }
            nextTime = Time.time + timeNext;
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        panel.SetActive(false);
        animator.SetBool("IsTalking", false);
    }
    IEnumerator Typing()
    {
        string currentDialogue = useAlternativeDialogue ? AlternativeDialogue[index] : dialogue[index];
        foreach (char letter in currentDialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void nextLine()
    {
        audioManager.playSFX(audioManager.Robot);
        nextButton.SetActive(false);
        if (index < (useAlternativeDialogue ? AlternativeDialogue.Length - 1 : dialogue.Length - 1))
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            nextButton.SetActive(true);
        }
        else
        {
            if (!useAlternativeDialogue)
            {
                useAlternativeDialogue = true;
                index = 0;
                dialogueText.text = "";
                panel.SetActive(false);
            }
            else
            {
                zeroText();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
