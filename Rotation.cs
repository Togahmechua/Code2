using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject knife;
    public GameObject knife2;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float knifeForce;

    private float timeBtwFire;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        Rotate();
        Buh();

        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            Fire();
        }
    }

    private void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = mousePos - transform.position;
        float Abcd = Mathf.Atan2(weaponPos.y, weaponPos.x) * Mathf.Rad2Deg; 

        Quaternion rotation = Quaternion.Euler(0 , 0 , Abcd);
        transform.rotation = rotation;
    }

    private void Buh()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z <270)
        {
            transform.localScale = new Vector3(1,-1,0);
        }
        else transform.localScale = new Vector3(1,1,0);
    }

    private void Fire()
    {
        timeBtwFire =TimeBtwFire;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z <270)
        {
        GameObject knifee = Instantiate(knife2 , firePos.position, firePos.rotation);
        Rigidbody2D rb = knifee.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * knifeForce, ForceMode2D.Impulse);
        }
        else 
        {
        GameObject knifeee = Instantiate(knife, firePos.position, firePos.rotation);
        Rigidbody2D rb = knifeee.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * knifeForce, ForceMode2D.Impulse);
        }
    }
}
