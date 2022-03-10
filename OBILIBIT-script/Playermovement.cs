using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playermovement : MonoBehaviour
{
    public static Playermovement instance;
    private Animator anim;  

    private float X,Y;
    private bool iswalking;
    private bool isattacking = true;
    private bool HIT = false;

    private float movespeed = 3.0f;    
    public Rigidbody2D rb;
    public Transform attackpoint ;
    public float attackrange = 0.5f;
    public LayerMask enemylayer ;
    public LayerMask objlayer ;
    public int damageAttack = 20;
    //private int enemyattack = 10;
    public int maxHPP = 100;
    private int currentDame ;

    Vector2 movement;
    public Image[] lives;
    public int livesRemaining;
    private void Awake() 
    {
        instance = this;
    }
    void Start() 
    {
        anim = GetComponent<Animator>(); 
        currentDame = maxHPP;
    }
    void Update() 
    {
        if (isattacking == true)
        {
            if ( Input.GetKeyDown(KeyCode.Space) )
            {
                isattacking = false;
                movespeed = 0.0f;
                Attack();                  
                StartCoroutine(attack_movemenet());                
                
            }
            else
            {
                movement.x = Input.GetAxis("Horizontal");
                movement.y = Input.GetAxis("Vertical"); 
                X = movement.x;
                Y = movement.y;        
                if (X != 0 || Y != 0)
                {
                    if (iswalking == false)
                    {
                        iswalking = true;
                        anim.SetBool("iswalking" , iswalking);
                    }                              

                    move();
                }
                else
                {
                    if (iswalking == true)
                    {
                        iswalking = false;
                        anim.SetBool("iswalking" , iswalking);
                    }
                }
                if (HIT == true)
                {
                    iswalking = false;
                    anim.SetBool("HIT" , HIT);
                } 
            }
        }
        
       
    }     

    private void move ()
    {
        anim.SetFloat("X", X);
        anim.SetFloat("Y", Y);

        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime );        

    }

    public IEnumerator knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        GetAttack();
        float timer = 0;
        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }
        anim.SetTrigger("hurt"); 
        yield return 0;
    }

    private void LoseLife()
    {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if (livesRemaining == 0)
        {
            Debug.Log("YOU LOST");
        }
    }
    void GetAttack()
    {        
        
        currentDame -= 1;
        Debug.Log("YOU hp :" + currentDame);
        if (currentDame %10 == 0)
        {
            LoseLife();
        }        
    } 
    private void die()
    {

    }

    public IEnumerator attack_movemenet()
    {                    
        yield return new WaitForSeconds(0.2f);
        isattacking = true;
        movespeed = 3.0f;
    }

    void Attack()
    {        
        anim.SetTrigger("attack");       

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange , enemylayer);
        Collider2D[] hitobj = Physics2D.OverlapCircleAll(attackpoint.position, attackrange , objlayer);

        foreach (Collider2D enemy in hitEnemies)
        {    
            Debug.Log("hit enemy");      
            enemy.GetComponent<enemy>().takedamage(damageAttack);            
        }
        foreach (Collider2D obj in hitobj)
        {
            Debug.Log("hit obj");
            obj.GetComponent<obj>().takedamageOBJ(damageAttack);
        } 
    }

    void OnDrawGizmosSelected() 
    {
        if (attackpoint == null)
        {
            return;
        }   

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }

}
