using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeleInteraction : MonoBehaviour
{
    [Header("Dialogue Connection")]
    public DialogueNode startNode;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(EventSystem.current.IsPointerOverGameObject() && PanelManager.Instance.IsPanelOpen)
            {
                Debug.Log("Cannot inspect item while panel is open.");
                return;
            }

            PanelManager.Instance.triggerPanelOpen(true);
            dialogueManager.InitiateDialogue(startNode);
        }
    }



}
