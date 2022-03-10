using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    public string newScene ;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.LoadScene(newScene, LoadSceneMode.Single);
    }
}
