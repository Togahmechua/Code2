using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float distance;
    public LayerMask whatisSolid;
    public int damage;
    public float FireForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * FireForce, ForceMode2D.Impulse);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
               hitInfo.collider.GetComponent<Player>().TakeDamge(damage);
            }
            Destroy(gameObject);
        }
    }
}
