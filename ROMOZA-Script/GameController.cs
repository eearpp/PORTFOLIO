using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayerPrefabI;
    public GameObject PlayerPrefabII;
    public GameObject PlayerPrefabIII;
    public GameObject PlayerPrefabIV;
    public GameObject PlayerPrefabV;
    public GameObject PlayerPrefabVI;
    public GameObject PlayerPrefabVII;
    public GameObject PlayerPrefabVIII;
    public float minX;
    public float maxX;
    public float minz;
    public float maxz;
    // Start is called before the first frame update
    void Start()
    {
        int spawn = Random.Range(1,9);
        if(spawn == 1)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabI.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 2)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabII.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 3)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabIII.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 4)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabIV.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 5)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabV.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 6)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabVI.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 7)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabVII.name,randomPotion,Quaternion.identity);
        }
        else if(spawn == 8)
        {
            Vector3 randomPotion = new Vector3(Random.Range(minX,maxX) ,0.1f, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(PlayerPrefabVIII.name,randomPotion,Quaternion.identity);
        }


        
    }



}
