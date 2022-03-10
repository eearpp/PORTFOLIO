using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DrestroyDown : MonoBehaviour
{
    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();  
    }

    void Update()
    {
    }

    void OnTriggerStay( Collider collsion )
    {
        if(collsion.gameObject.tag == "VerlocityMin")
        {
            if(view.IsMine)
            {
                Destroy(gameObject);
            }
        }
    }
}
