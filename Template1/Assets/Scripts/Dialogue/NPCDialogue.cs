using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private int dialogue;
    private DialogueUI dialogueUI;
    private bool playerEntered;
    private GameObject player;
    private DialogueController dialogueCont;
    private int currentDialogue = 1;

    private void Start()
    {
        dialogueCont = GetComponent<DialogueController>();
        dialogueUI = GameObject.FindGameObjectWithTag("UserInterface").GetComponentInChildren<DialogueUI>();
        dialogueUI.setActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerEntered)
        {
            if (player.transform.position.x > transform.position.x)
                this.transform.eulerAngles = new Vector3(0, 180, 0);
            else
               this.transform.eulerAngles = Vector3.zero;

            dialogueUI.setActive(true);
            dialogueUI.changeText(dialogueCont.getDialogue(currentDialogue));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerEntered = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerEntered = false;
            dialogueUI.setActive(false);
        }
    }


}
