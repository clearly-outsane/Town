using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class JoinButton : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;
    public string networkAddress = "3.21.50.128";

    public void OnClick()
    {
        networkManager.networkAddress = networkAddress;
#if (UNITY_WEBGL == true && UNITY_EDITOR == false)
        networkManager.networkAddress = "pleasefreedomain.tk";
#endif
        networkManager.StartClient();
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
