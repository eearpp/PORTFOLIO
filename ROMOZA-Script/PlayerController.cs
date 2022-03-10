using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;    
    public Vector3 forward;//----------for movement
    public Vector3 right;//----------for movement
    private Animator anim;

    public Rigidbody rb;
    public CapsuleCollider CapColli;
    PhotonView view;
    void Start()
    {
        anim = GetComponent<Animator>();
        //--------------------for move        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //--------------------for move
        rb = GetComponent<Rigidbody>();      //     initialize rigidbody reference
        CapColli = GetComponent<CapsuleCollider>();
        view = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if(view.IsMine)
        {            
            Move(); 
        }       
                   
    }

    void Move()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        if ( xDirection != 0 || zDirection != 0)
        {
            anim.SetBool("isRunning", true);
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //----------------Let's Move
            Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
            Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
            //----------------Let's Move
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            //--------------normalized
            /*rb.velocity = direction.normalized;
            rb.velocity = rightMovement.normalized;
            rb.velocity = upMovement.normalized;
            rb.velocity = heading.normalized;*/
            //--------------normalized
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }       

    }

}
