using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.AI;

public class DialogueManager : MonoBehaviour
{
    [Header("User Interface Reference")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;
    public Image speakerIcon;
    public Transform optionsContainer;
    public GameObject optionButtonPrefab;

    private HashSet<string> finishedNodeIds = new HashSet<string>();

    void Start()
    {
        dialoguePanel.SetActive(false);

    }

    public void InitiateDialogue(DialogueNode node)
    {
        dialoguePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DisplayNode(node);
    }

    public void DisplayNode (DialogueNode node)
    {
        finishedNodeIds.Add(node.nodeId);

        nameText.text = node.speakerName;
        contentText.text = node.dialogueText;

        speakerIcon.sprite = node.speakerIcon;

        OptionsRefresh(node);

    }

    public void OptionsRefresh(DialogueNode node)
    {
        foreach (Transform child in optionsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var option in node.options)
        {
            if(!string.IsNullOrEmpty(option.nodeIdRequired))
            {
                if (!finishedNodeIds.Contains(option.nodeIdRequired))
                {
                    continue;
                }
            }

            GameObject buttonObject = Instantiate(optionButtonPrefab, optionsContainer);
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = option.optionText;

            buttonObject.GetComponent<Button>().onClick.AddListener(() => DisplayNode(option.nextNode));

        }

    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        PanelManager.Instance.triggerPanelOpen(false);

    }

}
