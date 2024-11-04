using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetElevator : MonoBehaviour
{
    public Animator elevatorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenElevator()
    {
        elevatorAnimator.SetBool("Open", true);
    }
    public void CloseElevator()
    {
        elevatorAnimator.SetBool("Open", false);
    }
}
