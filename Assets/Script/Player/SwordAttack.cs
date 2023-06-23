using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;

    //Singleton 
    [SerializeField] PlayerData _playerData;

    [SerializeField] EnemyData _enemyData;
    public float dmg;
    public float EnemyHealth;
    public static float currentEHP;



    private void Start()
    {
        dmg = _playerData.damage;
        EnemyHealth = _enemyData.hp;
        rightAttackOffset = transform.position;
        Debug.Log(dmg);
    }



  
    public void AttackRight()//Khi di chuyển sang phải thì rightAttackOffset sẽ dương  
    {
        print("Right");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()//Khi di chuyển sang phải thì rightAttackOffset sẽ âm
    {
        print("Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }


    
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //Khi chém trúng Enemy thì Enemy sẽ bị trừ damage
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
            Debug.Log(dmg);
        }
        currentEHP = EnemyHealth;

    }

    
}
