using UnityEngine.UI;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    Vector2 Target;
    Rigidbody2D rig;
    Animator aim;
    public float RunDistance = 30f;
    public float teleTime;
    public bool isTele;
    public float speed;
    public BoxCollider2D box;
    private bool isFlip = false;
    private Vector2 initialPosition;
    private float _teleTime;

    public Slider liveSlider;

    bool haveGround;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
        initialPosition = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRun();
        
        Debug.DrawRay(initialPosition, Vector2.right * RunDistance, Color.green);
        Debug.DrawRay(initialPosition, Vector2.left * RunDistance, Color.green);
        if (!box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            haveGround = false;
        }
        else
        {
            haveGround = true;
        }
    }
    void CheckRun()
    {
        if (FindObjectOfType<PlayerTakeDamge>().isDeath == true)
        {
            aim.SetBool("Run", false);
            return;
        }
        var distance = Vector2.Distance(initialPosition,
                            target.position);
        if (distance < RunDistance && haveGround == true)
        {
            _teleTime = teleTime;
            aim.SetBool("Run", true);
            isTele = false;
            
        }
        else
        {
            isTele = true;
            aim.SetBool("Run", false);
            Tele();
        }
    }
    void Tele()
    {
        if (_teleTime <= 0 && isTele == true)
        {
            transform.position = initialPosition;
            isTele = false;
        }

        else
        {
            _teleTime -= Time.deltaTime;
        }
    }
    public void FlipAttack()
    {
        FindObjectOfType<PlayerTakeDamge>().FlipTakeDamge(isFlip);
    }
    
     public void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > target.position.x && isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
            liveSlider.direction = Slider.Direction.LeftToRight;
        }
        else if (transform.position.x < target.position.x && !isFlip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
            liveSlider.direction = Slider.Direction.RightToLeft;
        }
    }
}
