using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotting : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    private Animator animator;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length - 1);
            animator.SetTrigger("IsAttacking");
            Instantiate(bullet, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else 
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
