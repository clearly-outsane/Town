using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
#if (UNITY_WEBGL == true && UNITY_EDITOR == false)
    [DllImport("__Internal")]
    private static extern void JoinChannel(string channel);
#endif
    private void Start()
    {

#if (UNITY_WEBGL == true && UNITY_EDITOR == false)
            JoinChannel ("lol");
#endif

    }

}
