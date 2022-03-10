using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HoldAudio.holdAudio.gameObject.GetComponent<AudioSource>().Pause();
    }
}
