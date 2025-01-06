using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private bool playerInRange = false;
    [SerializeField] private TextAsset dialogue;
    [SerializeField] playerInteract interaction;

    private void Update()
    {
        if (playerInRange)
        {
            if (interaction.interacting)
            {
                Debug.Log(dialogue.text);
            }  
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
