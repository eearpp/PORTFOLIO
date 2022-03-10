using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    private bool ishurting  = true;
    private int maxHP = 60;
    int currentHP;
    private float knockbackPower = 20;
    private float knockbackDuration = 1;
    void Start()
    {
        currentHP = maxHP;
    }

    public void takedamage(int damage)
    {
        if (ishurting == true)
        {
            currentHP -= damage;
            animator.SetTrigger("hurt");            
            shakeCM.Instance.ShakeCamera(8f, 0.4f);            
            ishurting = false; 
            StartCoroutine(imunation());              
        }         
             
        if (currentHP <= 0)
        {
            die();
        }        
    }    

    void die ()
    {
        animator.SetBool("dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(wait());         
    }

    public IEnumerator imunation()
    {                  
        yield return new WaitForSeconds(0.7f);
        if (ishurting == false)
        {            
            ishurting = true;
        }        
    }

    public IEnumerator wait()
    {                  
        yield return new WaitForSeconds(3.0f);
        shakeCM.Instance.ShakeCamera(8f, 0.4f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Playermovement.instance.knockback(knockbackDuration,knockbackPower,this.transform));
        }
    }

    
}
