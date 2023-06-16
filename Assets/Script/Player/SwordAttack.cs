using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;

    public int dmg = 10;

    Vector2 rightAttackOffset;


    

    private void Start()
    {
        rightAttackOffset = transform.position;
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
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.Health -= this.dmg;
                Debug.Log(dmg);
            }
        }
    }

    
}
