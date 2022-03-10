using UnityEngine;
using UnityEngine.SceneManagement;
public class stage3_clicker : MonoBehaviour
{
    string Currentobj;
    public Camera cam;
    public string objname;
    public string Scenename;
    [SerializeField] AudioSource Beep;
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Beep.Play();
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            int cubeNumber = 0 ,left = 0,right = 0;
            if (Physics.Raycast(ray, out Hit))
            {
                Currentobj = Hit.transform.name;
                int.TryParse(Currentobj, out cubeNumber);
                if(Currentobj == objname)
                {
                    SceneManager.LoadScene(Scenename);
                }
                else if (cubeNumber == 0)
                {
                    left = 11;
                    right = 1;
                }
                else if (cubeNumber == 11)
                {
                    left = 10;
                    right = 0;
                }
                else if (cubeNumber > 0 && cubeNumber < 11)
                {
                    int a = cubeNumber;
                    int b = cubeNumber;

                    left = a-1;
                    right = b+1;
                }
                Hit.transform.GetComponent<stage3_cube>().swapColor(left,cubeNumber,right);
                Hit.transform.GetComponent<stage3_cube>().checkWin();
            }
        }
    }
}