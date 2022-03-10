using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Clock : MonoBehaviour, IPunObservable
{
    public float timeValue = 90;
    public Text timerText;
    PhotonView view;//-----------Photon for server view
    int stopp;
    //-----------------------------------------------
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(timeValue);
        }
        else
        {
            timeValue = (float)stream.ReceiveNext();
        }
    }
    //-----------------------------------------------
    void Start()
    {
        view = GetComponent<PhotonView>();
        StartCoroutine(Waiter());
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 60;
            }

            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            view.RPC("print",RpcTarget.All, minutes,seconds);
        }       

    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(420);
        stopp = 123456789;
    }

    [PunRPC]
    void print(float min ,float sec)
    {        
        if(stopp == 123456789)
        {
            timerText.text = "UNITY IS POWER";
        }
        else
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

}
