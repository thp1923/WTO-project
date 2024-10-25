using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHp;
        aim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
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
        if (HP <= 0)
        {
            aim.SetBool("Death", true);
            rig.gravityScale = 0;
            FindObjectOfType<GameSession>().upExp(exp);
            GetComponent<EnemyMove>().enabled = false;
            GetComponent<EnemyAttack>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
