using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    private float currentTime;
    public float TimetoDash;
    private float timetodash;
    public float speed = 5f;
    private Rigidbody2D rb;
    public SpriteRenderer character;

    public Animator animator;

    public Vector3 moveInput;

    private void Start()
    {
        currentTime =TimetoDash;
        timetodash = TimetoDash;
    }


    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput = moveInput.normalized;
        transform.position += moveInput * speed * Time.deltaTime;

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        Dash();
    }

    private void Dash()
    {
        timetodash -= Time.deltaTime; 
        if (timetodash <= 0)
        {
           if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.position += moveInput * speed * 120 * Time.deltaTime;
                timetodash = currentTime;
            }
           
        }
    }
}
