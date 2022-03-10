using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MapController : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public GameObject FloorSlideAssetI;
    public GameObject FloorSlideAssetII;
    public GameObject FloorSlideAssetIII;
    public GameObject FloorSlideAssetIV;
    public GameObject FloorSlideAssetV;
    public GameObject FloorSlideAssetVI;
    public GameObject Mapcontroller;
    public float TimeToColor = 1f;
    public float TimeToDelete = 1f;
    PhotonView view;
    private int uupdate = 0;
    //--------------------------------------------------------FOR Time

    public float WaitTime;
    private bool IsWaitPhase;
    private bool IsCounting;
    public int UUpdate;
    void Start()
    {
        view = GetComponent<PhotonView>();
        //StartCoroutine(waiter());
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(waiter());
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 1);
        //FloorSlideAssetI.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetI.transform.Translate(Vector3.down * 250f);

        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 2);
        //FloorSlideAssetII.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetII.transform.Translate(Vector3.down * 250f);

        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 3);
        //FloorSlideAssetIII.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetIII.transform.Translate(Vector3.down * 250f);

        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 4);
        //FloorSlideAssetIV.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetIV.transform.Translate(Vector3.down * 250f);

        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 5);
        //FloorSlideAssetV.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetV.transform.Translate(Vector3.down * 250f);

        yield return new WaitForSecondsRealtime(TimeToColor);
        view.RPC("ChangeIt", RpcTarget.All, 6);
        //FloorSlideAssetVI.GetComponent<MeshRenderer>().material = myMaterial;
        yield return new WaitForSecondsRealtime(TimeToDelete);
        FloorSlideAssetVI.transform.Translate(Vector3.down * 250f);


        yield return new WaitForSecondsRealtime(1);
        if (view.IsMine)
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    private void ChangeIt(int choice)
    {
        if (choice == 1)
        {
            FloorSlideAssetI.GetComponent<MeshRenderer>().material = myMaterial;
        }
        else if (choice == 2)
        {
            FloorSlideAssetII.GetComponent<MeshRenderer>().material = myMaterial;
        }
        else if (choice == 3)
        {
            FloorSlideAssetIII.GetComponent<MeshRenderer>().material = myMaterial;
        }
        else if (choice == 4)
        {
            FloorSlideAssetIV.GetComponent<MeshRenderer>().material = myMaterial;
        }
        else if (choice == 5)
        {
            FloorSlideAssetV.GetComponent<MeshRenderer>().material = myMaterial;
        }
        else if (choice == 6)
        {
            FloorSlideAssetVI.GetComponent<MeshRenderer>().material = myMaterial;
        }

    }


}
