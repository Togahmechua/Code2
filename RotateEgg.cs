using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEgg : MonoBehaviour
{
    public float speedRotate;
    public Vector3 rotateAxist;
    public float distance;
    public LayerMask whatisSolid;
    public int damage;
    
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
               hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Rotate(rotateAxist, speedRotate * Time.deltaTime);
        New();
        New2();
        New3();
    }

    private void New()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Square"))
            {
               hitInfo.collider.GetComponent<EnemySquare>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Rotate(rotateAxist, speedRotate * Time.deltaTime);
    }

        private void New2()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Tank"))
            {
               hitInfo.collider.GetComponent<EnemySquare>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Rotate(rotateAxist, speedRotate * Time.deltaTime);
    }

     private void New3()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Boss"))
            {
               hitInfo.collider.GetComponent<EnemyBoss>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Rotate(rotateAxist, speedRotate * Time.deltaTime);
    }
}
