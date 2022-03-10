using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AirDrop : MonoBehaviour
{
    PhotonView view;
    public GameObject parONE;
    public GameObject parTWO;
    public GameObject parTHREE;
    public GameObject parFOUR;
    public float minX;
    public float maxX;
    public float minz;
    public float maxz;
    bool fortime =false;
    void Start()
    {
        view = GetComponent<PhotonView>();
        fortime =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fortime == false)
        {
            StartCoroutine(airtime());
        }
    }

    IEnumerator airtime()
    {
        fortime = true;
        yield return new WaitForSecondsRealtime(30);
        fortime = false;
        Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,40, Random.Range(minz, maxz));
        int spawn = Random.Range(1,5);
        if(spawn == 1)
        {
            PhotonNetwork.Instantiate(parONE.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 2)
        {
            PhotonNetwork.Instantiate(parTWO.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 3)
        {
            PhotonNetwork.Instantiate(parTHREE.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 4)
        {
            PhotonNetwork.Instantiate(parFOUR.name,randomPotion,Quaternion.identity);
        }        
        //Instantiate(parONE,randomPotion,Quaternion.identity);
    }
}
