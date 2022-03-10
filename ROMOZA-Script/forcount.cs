using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class forcount : MonoBehaviourPunCallbacks, IPunObservable
{
    private Animator anim;
    public Text prefabUI;
    public int deadcount = 0;
    PhotonView view;
    private bool ironbb = false;
    //---------------------------
    float timer;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(deadcount);
        }
        else
        {
            deadcount = (int)stream.ReceiveNext();
        }
    }

    void Start()
    {
        
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        prefabUI.text = "HIDEHO";
    }
    
    public void Update()
    {
        prefabUI.text = deadcount.ToString();
    }

    public void Dead(int Deaded)
    {
        if(!view.IsMine)
            return;
        //-----------------------
        if (Deaded == 1 && ironbb == false)
        {
            ironbb = true;
            deadcount++;
            StartCoroutine(ironbody());
            Deaded = 0;
            anim.SetBool("isTaunt", true);            
        }
    }   

    IEnumerator ironbody()
    {
        yield return new WaitForSecondsRealtime(0.09f);
        ironbb = false;
    }
   /* public IEnumerator sendscore()
    {
        yield return new WaitForSecondsRealtime(5);
        gameObject.SendMessage("GetScored",45);
    }
*/
}
