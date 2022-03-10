using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] AudioSource Beep;
    public void LoadScene(string SceneName)
    {
        StartCoroutine(DeepAndLoad(SceneName));        
    }

    IEnumerator DeepAndLoad(string SceneName)
    {
        Beep.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);

    }
}
