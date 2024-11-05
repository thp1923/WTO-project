using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPostNotification : MonoBehaviour
{
    public Text instructionText;// Tham chiếu đến UI Text
    public GameObject postNotificationimage;
    public Transform player;     // Tham chiếu đến đối tượng Player
    public float triggerDistance = 3f; // Khoảng cách để hiện thông báo
    // Start is called before the first frame update
    void Start()
    {
        // Ẩn thông báo ban đầu
        instructionText.gameObject.SetActive(false);
        postNotificationimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Tính khoảng cách giữa người chơi và cọc
        float distance = Vector3.Distance(player.position, transform.position);

        // Nếu người chơi trong khoảng cách cho phép, hiện thông báo
        if (distance < triggerDistance)
        {
            instructionText.gameObject.SetActive(true);
            postNotificationimage.SetActive(true);
        }
        else
        {
            instructionText.gameObject.SetActive(false); // Ẩn khi đi xa
            postNotificationimage.SetActive(false);
        }
    }
}
