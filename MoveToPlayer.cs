using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private Transform player;
    public float distanceToPlayer;
    private float distance;
    private Rigidbody2D rb;
    private Animator animator;
    public  float speed;
    private Vector3 directionToPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position , player.transform.position);
        directionToPoint = (player.transform.position - transform.position).normalized;
        if (distanceToPlayer <= distance)
        {
        rb.velocity = new Vector2(directionToPoint.x, directionToPoint.y)*speed;
        animator.SetBool("IsMoving", true);
        }
        else
        {   
            rb.velocity = new Vector2(directionToPoint.x, directionToPoint.y) * speed * 0; 
            animator.SetBool("IsMoving", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToPlayer);
    }
}
