using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject Panel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public int indexLearn;
    public float timeNext = 1f;
    float nextTime;

    public GameObject nextButton;
    public GameObject learnButton;

    public float wordSpeed;
    public bool playerIsClose;
    public bool isLearn;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose == true && Time.time >= nextTime)
        {
            if(Panel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                Panel.SetActive(true);
                StartCoroutine(Typing());
            }
            nextTime = Time.time + timeNext;
        }
        if (dialogueText.text == dialogue[indexLearn] && isLearn)
        {
            learnButton.SetActive(true);
            nextButton.SetActive(false);
        }
        if(dialogueText.text == dialogue[index])
        {
            nextButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        
        dialogueText.text = "";
        index = 0;
        Panel.SetActive(false);
    }

    IEnumerator Typing()
    {
        
        foreach (char letter in dialogue[index].ToCharArray())
        {
            
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        
        nextButton.SetActive(false);
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            
            StartCoroutine(Typing());
        }
        else
        {
            
            zeroText() ;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
