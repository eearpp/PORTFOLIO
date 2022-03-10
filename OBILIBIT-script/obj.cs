using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj : MonoBehaviour
{
    
    //public Animator animator;
    private int objHP = 100;
    int currentHPOBJ;
    void Start()
    {
        currentHPOBJ = objHP;
    }

    public void takedamageOBJ(int OBJdamage)
    {
        currentHPOBJ -= OBJdamage;                      
        shakeCM.Instance.ShakeCamera(8f, 0.4f);        
                  
             
        if (currentHPOBJ <= -100)
        {
            die();
        }        
    }    

    void die ()
    {
        Destroy(gameObject);       
    }

    
}
