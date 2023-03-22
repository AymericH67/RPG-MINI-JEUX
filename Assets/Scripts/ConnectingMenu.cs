using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
