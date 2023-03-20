using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject ingameMenuPanel;

    private void Start()
    {
        ingameMenuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ingameMenuPanel.SetActive(!ingameMenuPanel.activeSelf);
        }
    }
}
