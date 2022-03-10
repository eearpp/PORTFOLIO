using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Parachutmyss : MonoBehaviour
{
    private PhotonView view;
    public GameObject ExpoldeParticle;
    public Transform parachutepoint;
    public GameObject Gparachutte;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void update()
    {
        if (parachutepoint.position.y <= 20)
        {
            Gparachutte.GetComponent<Rigidbody>().drag = 3f;
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("asdasdasdadadasd");
            StartCoroutine(WaiterBomb());
        }
    }

    IEnumerator WaiterBomb()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GameObject bombparticle = PhotonNetwork.Instantiate(ExpoldeParticle.name, parachutepoint.position, parachutepoint.rotation);
        if (view.IsMine)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
