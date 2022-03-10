using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
public class Sheep : MonoBehaviour
{
    public Transform BombPoint ;
    public GameObject ExpoldeParticle ;
    public GameObject bomb ;
    public float explodeTime = 5f;
    //---------------------------------------------------------------------------------
    public int MaxHits = 500;
    public float Radius = 10f;
    public LayerMask HitLayer;
    public LayerMask BlockExplosionLayer;
    public int MaxDamage = 50;
    public int MinDamage = 10;
    public float ExplosiveForce;
    private Collider[] Hits;
    private PhotonView view;
    //-----------------------------------------------------------------------For walking Random 

    public float timer;
    public float newtarget;
    public float speed;
    public NavMeshAgent nav;
    public Vector3 Target;
    public float Timerer = 0f;

    void Start()
    {
        Hits = new Collider[MaxHits];
        nav = gameObject.GetComponent<NavMeshAgent>();
        view = GetComponent<PhotonView>();
        StartCoroutine(WaiterBomb());  
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Timerer += Time.deltaTime;
        if(timer >= newtarget)
        {
            newTarget();
            timer = 0;
        }
        bomb.transform.Translate(Vector3.forward * 25f * Time.deltaTime);             
        
    }

    void newTarget()
    {
        float xpos = Random.Range(-323, -236);
        float zpos = Random.Range(-23 , 63);

        Target = new Vector3(xpos, gameObject.transform.position.y, zpos);
        nav.SetDestination(Target);

    }

    IEnumerator WaiterBomb()
    {
        yield return new WaitForSecondsRealtime(explodeTime);
        view.RPC("RPC_BombExplode",RpcTarget.All);
        GameObject bombparticle = PhotonNetwork.Instantiate("BombParticle", BombPoint.position, BombPoint.rotation);
        if(view.IsMine)
        {
            PhotonNetwork.Destroy(this.gameObject);
        } 
    }

    [PunRPC]
    public void RPC_BombExplode()
    {
        Ray ray = new Ray(BombPoint.position,BombPoint.forward);
        //Debug.Log(ray);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Debug.Log("It's work");            
            int hits = Physics.OverlapSphereNonAlloc(hit.point, Radius, Hits, HitLayer);

            for (int i = 0; i < hits; i++)
            {
                if (Hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    float distance = Vector3.Distance(hit.point, Hits[i].transform.position);

                    if (!Physics.Raycast(hit.point, (Hits[i].transform.position - hit.point).normalized, distance, BlockExplosionLayer.value))
                    {
                        rigidbody.AddExplosionForce(ExplosiveForce, hit.point, Radius);
                        //Debug.Log($"Would hit {rigidbody.name} for {Mathf.FloorToInt(Mathf.Lerp(MaxDamage, MinDamage, distance / Radius))}");
                    }
                } 
                if (Hits[i].TryGetComponent<Collider>(out Collider collider))
                {
                    if (collider.tag == "Player")
                    {
                       // collider.gameObject.SendMessage("Dead",1.0f);
                       var score = collider.GetComponent<forcount>();
                       if(score)
                       {
                            score.Dead(1);
                       }
                    }
                }             
                               
            }
        }
    }

}
