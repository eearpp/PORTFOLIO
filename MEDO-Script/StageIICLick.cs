using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageIICLick : MonoBehaviour
{
    public Text CurrentColorTExt;
    public Text ScoreText;
    public string Scenename;
    string Currentobj;
    string CurrentColor;
    public Camera cam;
    int score = 0;
    [SerializeField] AudioSource Beep;
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Beep.Play();
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                Currentobj = Hit.transform.name;
                if (Currentobj == CurrentColor)
                {
                    CurrentColorTExt.text = "Correct";
                    score ++ ;
                    ScoreText.text = "Score" + score.ToString();
                }
                else if(Currentobj != CurrentColor)
                {
                    CurrentColorTExt.text = "Wrong";
                    score -- ;
                    ScoreText.text = "Score" + score.ToString();
                }
            }
        }
        if(score >= 11)
        {
            SceneManager.LoadScene(Scenename);
        }
    }

    public void GetMainColor(int numcolor)
    {
        if (numcolor == 0)
        {
            CurrentColor = "BLACK";
        }
        else if (numcolor == 1)
        {
            CurrentColor = "BLUE";
        }
        else if (numcolor == 2)
        {
            CurrentColor = "GREEN";
        }
        else if (numcolor == 3)
        {
            CurrentColor = "ORANGE";
        }
        else if (numcolor == 4)
        {
            CurrentColor = "PURRLE";
        }
        else if (numcolor == 5)
        {
            CurrentColor = "RED";
        }
        else if (numcolor == 6)
        {
            CurrentColor = "WHITE";
        }
        else if (numcolor == 7)
        {
            CurrentColor = "YELLOW";
        }
    }
}
