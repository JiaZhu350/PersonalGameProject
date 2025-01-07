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
        if (playerInRange && !DialogueManager.GetInstance().playingDialogue)
        {
            if (interaction.interacting)
            {
                DialogueManager.GetInstance().EnterDialogue(dialogue);
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
