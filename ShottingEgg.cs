using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingEgg : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    public GameObject Egg;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float EggForce;//Lucban

    private float timeBtwFire;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        Rotate();
        Buh();

        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            animator.SetBool("isShotting", true);
            Fire();
        }
        else
        {
            animator.SetBool("isShotting", false);
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
        GameObject knifee = Instantiate(Egg , firePos.position, firePos.rotation);
        Rigidbody2D rb = knifee.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * EggForce, ForceMode2D.Impulse);
    }
}
