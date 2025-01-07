using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueContent;
    [SerializeField] playerInteract interaction;
    private static DialogueManager instance;
    private Story currentStory;
    public bool playingDialogue;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is a Duplicate");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() { return instance; }

    private void Start()
    {
        playingDialogue = false;
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (!playingDialogue)
        {
            return;
        }
        if (interaction.interacting)
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset dialogue)
    {
        currentStory = new Story(dialogue.text);
        playingDialogue = true;
        dialogueBox.SetActive(true);

        ContinueStory();
    }
    private IEnumerator ExitDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        playingDialogue = false;
        dialogueBox.SetActive(false);
        dialogueContent.text = "";
        
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueContent.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogue());
        }
    }
}
