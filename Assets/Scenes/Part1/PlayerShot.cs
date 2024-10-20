using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject shotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new shot
            var shot = Instantiate(shotPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            // Get the Rigidbody2D component of the shot
            var shotRb = shot.GetComponent<Rigidbody2D>();
            // Set the velocity of the shot
            shotRb.velocity = new Vector2(10, 0);
            // destroy the shot after 2 seconds
            Destroy(shot, 2);
            // Shake the camera
            CameraShake.Instance.ShakeCamera(5f, 0.1f);
        }
    }
}
