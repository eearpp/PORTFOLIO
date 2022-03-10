using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Kicking : MonoBehaviour
{
    public Transform KickPoint ;
    public GameObject TestBomb ;
    //-------------------For cool down
    public float timer;
    public float canKick;
    public float kickForce = 20f;
    // Update is called once per frame
    private PhotonView view;//-----------Photon for server view
    //------------------
    private string bombname = "SimpleBomb";
    void Start()
    {
        view = GetComponent<PhotonView>();
        timer = 3;
    }
    void Update()
    {
        if(view.IsMine)
        {
            timer += Time.deltaTime;
            if(timer >= canKick)
            {
                if(Input.GetButtonDown("Jump"))
                {
                    timer = 0;
                    Kick();
                }
            }            
        }        
    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "paraI")
        {
           bombname = "StickyBomb";
           canKick = 0;
        }
        if(collision.gameObject.tag == "paraII")
        {
           bombname = "Sheep";
           canKick = 0.5f;
        }
        if(collision.gameObject.tag == "paraIII")
        {
           bombname = "hallelujah";
           canKick = 1;
        }
        if(collision.gameObject.tag == "paraIV")
        {
           bombname = "Banana";
           canKick = 1.5f;
        }
    }

    void Kick()
    {
        if(bombname == "Banana")
        {
            GameObject bullet = PhotonNetwork.Instantiate(bombname, KickPoint.position, KickPoint.rotation);
            GameObject bullete = PhotonNetwork.Instantiate(bombname, KickPoint.position + new Vector3(2, 0,0), KickPoint.rotation);
            GameObject bulleted = PhotonNetwork.Instantiate(bombname, KickPoint.position+ new Vector3(0, 0 ,2), KickPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Rigidbody rbb = bullete.GetComponent<Rigidbody>();
            Rigidbody rbbb = bulleted.GetComponent<Rigidbody>();
            rb.AddForce(KickPoint.forward * kickForce , ForceMode.Impulse);
            rbb.AddForce(KickPoint.forward * kickForce , ForceMode.Impulse);
            rbbb.AddForce(KickPoint.forward * kickForce , ForceMode.Impulse);
        }
        else
        {
            GameObject bullet = PhotonNetwork.Instantiate(bombname, KickPoint.position, KickPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(KickPoint.forward * kickForce , ForceMode.Impulse);
        }
        /*GameObject bullet = Instantiate(TestBomb, KickPoint.position, KickPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(KickPoint.forward * kickForce , ForceMode.Impulse);*/
    }
}
