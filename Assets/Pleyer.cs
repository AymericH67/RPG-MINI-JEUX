using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pleyer : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isOpen == false)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }

    private void OpenPauseMenu()
    {
        pausePanel.SetActive(true);
        isOpen = true;
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
        isOpen = false;
    }

    public void OnExitGame()
    {
        print("exit game");
        SceneManager.LoadScene("Menu");
    }
}
