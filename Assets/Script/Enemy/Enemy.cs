using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
                

            }
        }
        get
        {
            return health;
        }
    }


    public float health = 1;


    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
    public void Defeated()
    {
        
        animator.SetTrigger("Defeated");
    }

    public void Die()
    {
        GetComponent<LootBag>().SpawnLoot(transform.position);
        Destroy(gameObject);
    }
}
