using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 afterCheatScale;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObject.transform.localScale = afterCheatScale;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.transform.localScale = startScale;
        }
    }
}
