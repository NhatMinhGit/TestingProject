using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseCharacter
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    //Khai báo animation
    Animator animator;

    List<RaycastHit2D> castCollisons = new List<RaycastHit2D>();//

    bool canMove = true;

    

    [SerializeField] List<ItemBase> ItemsEquipped = new List<ItemBase>();
    //AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        // khai báo rb là component RigidBody2D
        rb = GetComponent<Rigidbody2D>();
        
        // khai báo animator là component Animator
        animator = GetComponent<Animator>();

        // khai báo spriteRenderer là component SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        

    }



    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                //---Trượt qua bề mặt ngăn cản ---//
                if (!success && movementInput.x > 0 /* movementInput.x > 0 dùng để xác định có vật để dùng animation lại*/ )
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // Chỉnh hướng cho animation 
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                

            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
              
            }
        }
    }


    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            //Di chuyen

            int count = rb.Cast(direction, movementFilter, castCollisons, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
        

            if (count == 0)
            {
         
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }

            //----//
        }
        else
        {
     
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    
    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }
    
    public void SwordAttack()
    {
        LockMovement();
        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
        
    }
    public override void Atk(BaseCharacter baseCharacter)
    {
        int baseDmg = this.dmg;
        foreach(ItemBase i in ItemsEquipped)
        {
            dmg += i.atk;
        }
        baseCharacter.GetDmg(baseDmg);
    }

    public override void GetDmg(int dmg)
    {
        int trueDmg = dmg;
        foreach (ItemBase i in ItemsEquipped)
        {
            dmg += i.def;
        }
        HP -= trueDmg;
    }
    public void EquippedItem(ItemBase item)
    {
        ItemsEquipped.Add(item);
        item.Effect(this,true);
    }
    public void UnEquippedItem(ItemBase item)
    {
        ItemsEquipped.Remove(item);
        item.Effect(this,false);
    }
    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement() 
    {
        canMove = true;
    }
    
}
public abstract class BaseCharacter: MonoBehaviour
{
    public int HP = 15;
    public int dmg = 0;
    public abstract void Atk(BaseCharacter baseCharacter);

    public abstract void GetDmg(int dmg);
    
}
