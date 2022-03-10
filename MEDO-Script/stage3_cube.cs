using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage3_cube : MonoBehaviour
{
    [SerializeField] Material[] colorMat;
    [SerializeField] Text Debugg;
    public Renderer rend;
    public GameObject obj;

    public void setColor(int numcolor)
    {
        if(numcolor == 0)
        {
            rend.sharedMaterial = colorMat[0];
        }
        else if(numcolor == 1)
        {
            rend.sharedMaterial = colorMat[1];
        }
    }

    public void checkWin()
    {

        int[] colorBox = new int[12];
        for (int i = 0; i < 12; i++)
        {
            int j = i;
            Debugg.text = i + "";

            GameObject mainCube = GameObject.Find(j.ToString());
            Renderer rend = mainCube.GetComponent<Renderer>();
            rend.enabled = true;

            if (rend.sharedMaterial == colorMat[0])
            {
                colorBox[i] = 0;
            }
            else if (rend.sharedMaterial == colorMat[1])
            {
                colorBox[i] = 1;
            }
            else
            {
                colorBox[i] = 2;
            }
        }
        Debugg.text =
            colorBox[0].ToString() + "." +
            colorBox[1].ToString() + "." +
            colorBox[2].ToString() + "." +
            colorBox[3].ToString() + "." +
            colorBox[4].ToString() + "." +
            colorBox[5].ToString() + "." +
            colorBox[6].ToString() + "." +
            colorBox[7].ToString() + "." +
            colorBox[8].ToString() + "." +
            colorBox[9].ToString() + "." +
            colorBox[10].ToString() + "." +
            colorBox[11].ToString();
        
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
            if (a == 1 && b == 11)
            {
                SceneManager.LoadScene("SCENE_");
            }
            if (a == 11 && b == 1)
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
            }*/
        }

    }

    public void swapColor(int left,int cubeNumber,int right)
    {
        //Call SetColor using the shader property name "_Color" and setting the color to red

        GameObject leftCube = GameObject.Find(left.ToString());
        Renderer cubeRenderer = leftCube.GetComponent<Renderer>();
        cubeRenderer.enabled = true;
        if (cubeRenderer.sharedMaterial == colorMat[1])
        {
            cubeRenderer.sharedMaterial = colorMat[0];
        }
        else if (cubeRenderer.sharedMaterial == colorMat[0])
        {
            cubeRenderer.sharedMaterial = colorMat[1];
        }

        GameObject mainCube = GameObject.Find(cubeNumber.ToString());
        Renderer cubeRenderer2 = mainCube.GetComponent<Renderer>();
        cubeRenderer2.enabled = true;
        if (cubeRenderer2.sharedMaterial == colorMat[1])
        {
            cubeRenderer2.sharedMaterial = colorMat[0];
        }
        else if (cubeRenderer2.sharedMaterial == colorMat[0])
        {
            cubeRenderer2.sharedMaterial = colorMat[1];
        }

        GameObject rightCube = GameObject.Find(right.ToString());
        Renderer cubeRenderer3 = rightCube.GetComponent<Renderer>();
        cubeRenderer3.enabled = true;
        if (cubeRenderer3.sharedMaterial == colorMat[1])
        {
            cubeRenderer3.sharedMaterial = colorMat[0];
        }
        else if (cubeRenderer3.sharedMaterial == colorMat[0])
        {
            cubeRenderer3.sharedMaterial = colorMat[1];
        }

        
    }


}
