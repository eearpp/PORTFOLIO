using UnityEngine;
public class stage3_genCube : MonoBehaviour
{
    public GameObject[] cubeObject = new GameObject[12];
    int[] cube = new int[12];

    private void Start()
    {
        setZero();
        RandDom();
        Sent();

    }

    void setZero()
    {
        //Debug.Log("SetZero");
        for (int i = 0; i < 12; i++)
        {
            cube[i] = 0;
        }
    }

    void RandDom()
    {
        //Debug.Log("Random");
        int count = 0;
        while (true)
        {
            int rnd = Random.Range(0, 12);
            if (cube[rnd] == 0)
            {
                cube[rnd] = 1;
                //Debug.Log(rnd +" = " + cube[rnd]);
                count++;
            }            
            if (count == 4)
                break;
        }
    }

    void Sent()
    {
        for (int i = 0; i < 12; i++)
        {
            if (cube[i] == 0)
            {
                GameObject Cuben = cubeObject[i];
                Cuben.GetComponent<stage3_cube>().setColor(0);
            }
            else
            {
                GameObject Cuben = cubeObject[i];
                Cuben.GetComponent<stage3_cube>().setColor(1);
            }
        }
    }
}
