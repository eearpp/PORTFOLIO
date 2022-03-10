using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorcon : MonoBehaviour
{
    [SerializeField] GameObject cubemain;
    [SerializeField] Material[] material;
    Renderer rend;
    //------FOR COOLDOWN
    [SerializeField] float CooldownTime;
    private float nextChangeTime = 0;
    //------------------------
    private StageIICLick _StageIICLick;
    public GameObject Camma;
    void Start()
    {
        _StageIICLick = Camma.GetComponent<StageIICLick>();
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
    }
    void Update()
    {
        if(Time.time > nextChangeTime)
        {            
           // Debug.Log("B");  
            int numcolor = Random.Range(0, 8);  
            _StageIICLick.GetMainColor(numcolor);
            rend.sharedMaterial = material[numcolor];          
            nextChangeTime = Time.time + CooldownTime;
        }
    }
    

}
