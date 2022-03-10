using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CudeClick : MonoBehaviour
{
    public string objname;
    public string Scenename;
    string Currentobj;
    public Camera cam;
    [SerializeField] AudioSource Beep;

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Beep.Play();
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                Currentobj = Hit.transform.name;
                if(Currentobj == objname)
                {
                    SceneManager.LoadScene(Scenename);
                }
            }
        }
    }
}
