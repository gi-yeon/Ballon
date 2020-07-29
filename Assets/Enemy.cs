using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    Animator animator;
    public Transform player;
    public float speed;
    public Vector2 home;
    public float atkCooltime = 2;
    public float atkDelay;
    public float atkspeed;
    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        home = transform.position;
    }

    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
        {
            animator.SetFloat("Direction", -1);
        }
        else
        {
            animator.SetFloat("Direction", 1);
        }
    }

    private void Update()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
}
