using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3_chackWin : MonoBehaviour
{
    [SerializeField] Material[] Matcheck;
    [SerializeField] Text Debugg;
    public void checkWin()
    {
        GameObject ThisCube;
        Renderer ThisCudeRender;

        int[] colorBox = new int[12];
        for(int i = 0;i < 12; i++)
        {
            Debugg.text = i+"";
            ThisCube = GameObject.Find(i.ToString());
            ThisCudeRender = ThisCube.GetComponent<Renderer>();
            if(ThisCudeRender.material == Matcheck[0])
            {
                colorBox[i] = 0;
            }
            else if (ThisCudeRender.material == Matcheck[1])
            {
                colorBox[i] = 1;
            }
        }
        Debugg.text = 
            colorBox[0].ToString() + "," +
            colorBox[1].ToString() + "," +
            colorBox[2].ToString() + "," +
            colorBox[3].ToString() + "," +
            colorBox[4].ToString() + "," +
            colorBox[5].ToString() + "," +
            colorBox[6].ToString() + "," +
            colorBox[7].ToString() + "," +
            colorBox[8].ToString() + "," +
            colorBox[9].ToString() + "," +
            colorBox[10].ToString() + "," +
            colorBox[11].ToString();
        return;
        /*
        int a = 0, b = 0;
        for (int i = 0; i < 12; i++)
        {
            if(colorBox[i] == 0)
            {
                a += 1;
            }
            if(colorBox[i] == 1)
            {
                b += 1;
            }
            if (a == 12 || b == 12)
            {
                SceneManager.LoadScene("SCENE_");
            }

                /*
            if(colorBox[i] != colorBox[0])
            {
                break;
            }
            else if(colorBox[i] == colorBox[0] && i == 11)
            {
                SceneManager.LoadScene("SCENE_");
            }
        }*/
       

    }
}
