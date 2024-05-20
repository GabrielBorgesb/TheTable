using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInteract : MonoBehaviour
{
    public bool isPlayerInside;
    public GameObject playerInside;

    private void Update()
    {
        if (isPlayerInside)
        {
            if(Input.GetKeyDown(KeyCode.F) && !playerInside.GetComponent<PlayerInteract>().isOnTable)
            {
                StartCoroutine(EnterTableMode());
            }else if(Input.GetKeyDown(KeyCode.F) && playerInside.GetComponent<PlayerInteract>().isOnTable)
            {
                StartCoroutine(ExitTableMode());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            playerInside = other.gameObject;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = null;
        }
    }

    

    

    public IEnumerator EnterTableMode()
    {
        if (playerInside == null) yield break;

        playerInside.GetComponent<PlayerInteract>().isOnTable = true;
        CamerasManager.instance.vcamTable.gameObject.SetActive(true);
        playerInside.GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(0.6f);

        playerInside.GetComponent<PlayerMovement>().canMove = false;
        playerInside.GetComponent<PlayerManager>().playerHero.GetComponent<PlayerHeroMovement>().enabled = true;
    }

    public IEnumerator ExitTableMode()
    {
        if (playerInside == null) yield break;

        playerInside.GetComponent<PlayerInteract>().isOnTable = false;
        CamerasManager.instance.vcamTable.gameObject.SetActive(false);
        playerInside.GetComponent<PlayerMovement>().enabled = true;
        playerInside.GetComponent<PlayerManager>().playerHero.GetComponent<PlayerHeroMovement>().enabled = false;
        playerInside.GetComponent<PlayerManager>().playerHero.GetComponent<Animator>().SetBool("running", false);


        yield return new WaitForSeconds(0.6f);

        playerInside.GetComponent<PlayerMovement>().canMove = true;
        
    }
}


