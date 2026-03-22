using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueNode", menuName = "Dialogue/Dialogue Node")]
public class DialogueNode : ScriptableObject
{
    [Header("Dialogue Content")]
    [TextArea(3, 10)]
    public string dialogueText;

    [Header("Dialogue Options")]
    public DialogueOption[] options;

    [Header("ID Lock")]
    public string nodeId;

    [Header("Speaker Info")]
    public string speakerName;
    public Sprite speakerIcon;


}

[System.Serializable]
public struct DialogueOption
{
    public string optionText;
    public DialogueNode nextNode;

    [Header("ID Lock Required")]
    public string nodeIdRequired;
}