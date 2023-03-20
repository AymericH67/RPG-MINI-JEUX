using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannectionMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
        StartCoroutine(Waite());
    }

    private IEnumerator Waite()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
