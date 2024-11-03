using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyTakeDamge : MonoBehaviour
{
    public int maxHp;
    int HP;
    public GameObject Hit;
    Animator aim;
    Rigidbody2D rig;

    public int Def;
    public int exp;

    public GameObject damPopUp;
    public Slider liveSlider;

    AudioManager audioManager;

    private void Awake()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogError("AudioManager object with tag 'Audio' not found!");
        }
    }

    void Start()
    {
        HP = maxHp;
        aim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        if (aim == null) Debug.LogError("Animator component missing!");
        if (rig == null) Debug.LogError("Rigidbody2D component missing!");
        if (liveSlider == null) Debug.LogError("Slider not assigned in the Inspector!");
        if (damPopUp == null) Debug.LogError("damPopUp prefab not assigned!");
        if (Hit == null) Debug.LogError("Hit prefab not assigned!");

        liveSlider.maxValue = maxHp;
        liveSlider.value = maxHp;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int Base, float SkillDamge)
    {
        int HPlost = (int)(Base +(SkillDamge/Def)*3);
        HP -= HPlost;
        aim.SetTrigger("Hit");
        GameObject instance = Instantiate(damPopUp, transform.position
            + new Vector3(UnityEngine.Random.Range(-0.7f, 0.7f), 0.5f, 0), Quaternion.identity);
        instance.GetComponentInChildren<TextMeshProUGUI>().text = HPlost.ToString();
        Animator animator = instance.GetComponentInChildren<Animator>();
        Instantiate(Hit, rig.position, transform.rotation);
        liveSlider.value = HP;
        audioManager.playSFX(audioManager.Hit);
        if (HP <= 0)
        {
            aim.SetBool("Death", true);
            rig.gravityScale = 0;
            FindObjectOfType<GameSession>().upExp(exp);
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<EnemyMove>().enabled = false;

            EnemyAttack enemyAttack = GetComponent<EnemyAttack>();
            SceneManager.LoadScene(2);
            if (enemyAttack != null)
            {
                enemyAttack.enabled = false;
            }
            else
            {
                Debug.LogWarning("EnemyAttack component not found on this object.");
            }

        }
    }
}
