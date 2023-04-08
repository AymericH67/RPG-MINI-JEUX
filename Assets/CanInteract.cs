using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CanInteract : MonoBehaviour
{
    public Marchand marchand;
    private Inventory inventory;
    public PlayerStats playerStats;

    public Item obj;

    private GameObject marchandGameObj;
    public GameObject dropPoint;

    public bool canMarchandages = false;

    [Header("MarchandagesPanel")]
    public GameObject panel;
    public Image article1;
    public Image article2;
    public Image article3;
    public Image article4;
    public Image article5;
    public Image article6;

    public Text price1;
    public Text price2;
    public Text price3;
    public Text price4;
    public Text price5;
    public Text price6;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (canMarchandages == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                StartMarchandages();
            }
        }
    }

    private void StartMarchandages()
    {
        panel.SetActive(true);

        article1.sprite = marchand.Item1.visual;
        article2.sprite = marchand.Item2.visual;
        article3.sprite = marchand.Item3.visual;
        article4.sprite = marchand.Item4.visual;
        article5.sprite = marchand.Item5.visual;
        article6.sprite = marchand.Item6.visual;

        price1.text = marchand.Item1.priceString;
        price2.text = marchand.Item2.priceString;
        price3.text = marchand.Item3.priceString;
        price4.text = marchand.Item4.priceString;   
        price5.text = marchand.Item5.priceString;
        price6.text = marchand.Item6.priceString;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marchand")
        {
            marchand = other.GetComponent<Marchand>();
            canMarchandages = true;
            marchandGameObj = other.gameObject;
            marchandGameObj.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Marchand")
        {
            marchandGameObj.GetComponent<NavMeshAgent>().isStopped = false;
            marchand = null;
            canMarchandages = false;
            marchandGameObj = null;
            panel.SetActive(false);
        }
    }

    public void Image1Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item1.price)
        {
            Instantiate(marchand.dropItem1, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item1.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }

    }

    public void Image2Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item2.price)
        {
            Instantiate(marchand.dropItem2, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item2.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }
    }

    public void Image3Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item3.price)
        {
            Instantiate(marchand.dropItem3, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item3.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }
    }

    public void Image4Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item4.price)
        {
            Instantiate(marchand.dropItem4, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item4.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }
    }

    public void Image5Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item5.price)
        {
            Instantiate(marchand.dropItem5, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item5.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }
    }

    public void Image6Cilck()
    {
        // faire avec le instantiate voir sur monstre ai

        if (playerStats.coins >= marchand.Item6.price)
        {
            Instantiate(marchand.dropItem6, marchand.dropPoint.transform.position, Quaternion.identity);
            playerStats.coins -= marchand.Item6.price;
        }
        else
        {
            print("vous n'avez pas assez d'argent");
        }
    }

    public void CloseButton()
    {
        panel.SetActive(false);
    }
}
