using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MeetingManager : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<NetworkIdentity>().hasAuthority) return;
        Debug.Log("Player entered");
#if (UNITY_ANDROID == true)
        UnityMessageManager.Instance.SendMessageToRN("enter");
#endif
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.GetComponent<NetworkIdentity>().hasAuthority) return;
        Debug.Log("Player exited");
#if (UNITY_ANDROID == true)
        UnityMessageManager.Instance.SendMessageToRN("exit");
#endif
    }


}
