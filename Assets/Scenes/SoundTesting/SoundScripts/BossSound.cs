using UnityEngine;

public class BossSound : MonoBehaviour
{
    public AudioClip bossfight;
    AudioManager audioManager;
    private BoxCollider2D zoneCollider;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        zoneCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Capsule"))
        {
            Debug.Log("Player entered boss zone");
            audioManager.ChangeMusic(bossfight);
            zoneCollider.enabled = false;
        }
    }
}
