using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform targetLocation;
    public float teleportDelay = 0.25f;
    public Animator elevatorAnimator;

    private bool isOpen;
    private bool isMoving;
    private bool isTeleporting;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           if (!isOpen)
            {
                OpenElevator();
            }
        }
    }
    private void OpenElevator()
    {
        isOpen = true;
        elevatorAnimator.SetBool("Open", true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOpen)
        {
            CloseElevator();
        }
    }
    private void CloseElevator()
    {
        isOpen = false;
        elevatorAnimator.SetBool("Open", false);
        StartCoroutine(MoveAndTeleport());
    }
    private IEnumerator MoveAndTeleport()
    {
        isMoving = true;
        isTeleporting = true;
        player.GetComponent<SpriteRenderer>().enabled = false;
        float time = 0f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            yield return null;
        }
        isMoving = false;

        yield return new WaitForSeconds(teleportDelay);
        player.position = targetLocation.position;
        player.GetComponent<SpriteRenderer>().enabled = true;
        isTeleporting = false;
        TargetElevator targetElevator = targetLocation.GetComponent<TargetElevator>();
        if (targetElevator != null)
        {
            targetElevator.OpenElevator();
        }
        yield return new WaitForSeconds(0.25f);
        if (targetElevator != null)
        {
            targetElevator.CloseElevator();
        }
    }
}
