using UnityEngine;
using System.Collections;

public class AnimatePlayer : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("RotateLeftAnimation");
        } else if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isRotating", false);
        }
    }
}