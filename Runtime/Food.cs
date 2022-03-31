using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "__Eat__")
        {
            //Debug.Log("EAT ME!!!");
            GetComponent<PhotonView>().RPC("RPC_EatMe", RpcTarget.AllBufferedViaServer);
        }
    }

    [PunRPC]
    protected virtual void RPC_EatMe()
    {
        gameObject.SetActive(false);
    }
}
