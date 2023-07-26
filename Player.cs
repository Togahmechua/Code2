using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public GameObject effectded;
    public Playerstats pls;
    [SerializeField]  int Maxhealth;
    [SerializeField]  int currentHealth;
    public UnityEvent OnDeath;
    public float SafeTime = 1f;
    public float _SafeTimeCD;
     
    private void Start()
    {
        currentHealth = Maxhealth;
        pls.UpdateBar(currentHealth, Maxhealth);
        OnDeath.AddListener(Death);
    }

    private void Update()
    {
        _SafeTimeCD -= Time.deltaTime;
    }

    public void TakeDamge(int damge)
    {
        if (_SafeTimeCD <= 0)
        {
        currentHealth -= damge;
        GameObject effect = Instantiate(effectded, this.transform.position, Quaternion.identity);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        pls.UpdateBar(currentHealth, Maxhealth);
        _SafeTimeCD = SafeTime;
        }
    }

    public void Death()
    {
     Destroy(gameObject);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamge(10);
            Debug.Log("Player is attacked");
        }

        else if (collision.CompareTag("Square"))
        {
            TakeDamge(5);
        }

        else if (collision.CompareTag("TankBullet"))
        {
            TakeDamge(2);
        }
    }
}
