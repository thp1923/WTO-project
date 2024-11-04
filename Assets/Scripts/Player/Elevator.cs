using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorDoors;
    public Transform targetLocation;
    public float teleportDelay = 0.25f;

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
        StartCoroutine(MoveAndTeleport());
    }
    private IEnumerator MoveAndTeleport()
    {
        isMoving = true;
        isTeleporting = true;
        player.GetComponent<SpriteRenderer>().enabled = false;
        float time = 0f;
        float duration = 2f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            elevatorDoors.localPosition = Vector3.Lerp(elevatorDoors.localPosition, targetLocation.localPosition, t);
            yield return null;
        }
        isMoving = false;
        isOpen = false;

        yield return new WaitForSeconds(teleportDelay);
        player.position = targetLocation.position;
        player.GetComponent<SpriteRenderer>().enabled = true;
        isTeleporting = false;
    }
}
