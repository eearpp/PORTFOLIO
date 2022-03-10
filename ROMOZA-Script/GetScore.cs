using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    PhotonView view;
    public List<int> scoreList = new List<int>();
    public Text ssccrr;
    void Start()
    {
        view = GetComponent<PhotonView>();
        ssccrr.text = "Hi";
    }
    int asd = 5;
    void Update()
    {
        ssccrr.text = asd.ToString();
    }
    public void GetScored(int score)
    {
        //scoreList.Add(score);
        asd = score;       
    }
}
