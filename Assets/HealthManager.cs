using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthImage;
    public float fillHealthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fillHealthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Heal(5);
        }
    }
    public void TakeDamage(float damage)
    {
        fillHealthAmount -= damage;
        HealthImage.fillAmount = fillHealthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        fillHealthAmount += healingAmount;
        fillHealthAmount = Mathf.Clamp(fillHealthAmount, 0, 100);

        HealthImage.fillAmount = fillHealthAmount / 100f;
    }
}
