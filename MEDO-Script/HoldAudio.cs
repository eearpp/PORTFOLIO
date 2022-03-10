using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAudio : MonoBehaviour
{
    private static HoldAudio _HoldAudio;
    public static HoldAudio holdAudio
    {
        get { return _HoldAudio;  }
    }

    private void Awake()
    {
        if(_HoldAudio != null && _HoldAudio != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _HoldAudio = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
