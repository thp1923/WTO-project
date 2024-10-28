using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance;

    public bool canRecceiveInput;
    public bool inputRecceived;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        canRecceiveInput = true;
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            if (canRecceiveInput)
            {
                
                inputRecceived = true;
                canRecceiveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        if (!canRecceiveInput)
        {
            canRecceiveInput = true;
        }
        else
        {
            canRecceiveInput = false;
        }
    }
}
