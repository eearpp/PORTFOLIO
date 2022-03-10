using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class managerController : MonoBehaviour
{
    private CharacterController _chaController;
    public float speed = 1f;
    PhotonView view;//-----------Photon for server view

    public Vector3 forward;//----------for movement
    public Vector3 right;//----------for movement
    Vector3 moveVector = Vector3.zero;
    private Animator anim;
    private float xDirection;
    private float zDirection;

    public float gravity = 30.0f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject PPlayer;
    public Transform PPlaterTr;
    public Transform tpLoc;
    public GameObject ExpoldeParticle ;
    //----------------------------------------------------Respawn
    // Start is called before the first frame update
    void Start()
    {
        GameObject temPlayer = GameObject.FindGameObjectWithTag("Player");
        _chaController = temPlayer.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //--------------------for move        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //--------------------for move
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        //Debug.Log(gravity);
        moveDirection.y -= gravity * Time.deltaTime;
        _chaController.Move(moveDirection * Time.deltaTime);
        if (view.IsMine)
        {
            Move();
            if (Input.GetButtonDown("e"))
            {
                anim.SetBool("isTaunt", true);
            }

        }
        //myText.text = count;
    }

    void OnTriggerStay( Collider collsion )
    {
        if(collsion.gameObject.tag == "Hero")
        {
            StartCoroutine(forre());
        }
    }

    IEnumerator forre()
    {
        //GameObject bombparticle = PhotonNetwork.Instantiate("BombParticle", PPlaterTr.position, PPlaterTr.rotation);
        GameObject bombparticle = Instantiate(ExpoldeParticle, PPlaterTr.position, PPlaterTr.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        PPlayer.transform.position = tpLoc.transform.position;
    }

    private void Move()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        if (xDirection != 0 || zDirection != 0)
        {
            anim.SetBool("isTaunt", false);
            anim.SetBool("isRunning", true);
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

            Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = heading;
            _chaController.Move(rightMovement);
            _chaController.Move(upMovement);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

}
