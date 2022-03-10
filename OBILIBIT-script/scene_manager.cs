using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public void change_scene(string game_play)
    {
       // StartCoroutine(attack_movemenet()); 
        SceneManager.LoadScene(game_play);
    }


    /*public IEnumerator attack_movemenet()
    {                 
        yield return new WaitForSeconds(6.0f);
    }*/
}
