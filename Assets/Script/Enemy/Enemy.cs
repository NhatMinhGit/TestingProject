using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float Health;
    public float Damage;
    public float distance;
    [SerializeField] GameObject player;
    Rigidbody2D rigi;
    [SerializeField] float speed;
    [SerializeField] float detectRadius;
    [SerializeField] float attackRadius;
    [SerializeField] EnemyData _enemyData;
    Vector3 movement;
    private void Start()
    {
        speed = _enemyData.speed;
        detectRadius = _enemyData.detectRadius;
        attackRadius = _enemyData.attackRadius;

        Health = SwordAttack.currentEHP;
        Debug.Log(Health);
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().gameObject;
        rigi = this.gameObject.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        CheckDistance();
    }
    
    private void CheckDistance()
    {

        Vector3 direct = player.transform.position - this.transform.position;
        Debug.DrawRay(this.transform.position, direct, Color.white);
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        Debug.Log(distance);
        movement = rigi.velocity;
        if (distance <= detectRadius && distance > attackRadius)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed * Time.deltaTime);
            Move();
        }
        
    }
    

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Defeated();
        }
    }

    public void Move()
    {
        animator.SetTrigger("Move");
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
