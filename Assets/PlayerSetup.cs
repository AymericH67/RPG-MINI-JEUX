using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDesable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDesable.Length; i++)
            {
                componentsToDesable[i].enabled = false;
            }
        }
    }
}
