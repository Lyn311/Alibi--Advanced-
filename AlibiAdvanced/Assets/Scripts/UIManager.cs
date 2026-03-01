using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI itemInfoText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }

    public void ItemInfoDisplay(ItemInfo _info)
    {
        itemInfoText.text = $"{_info.itemName}:{_info.description}";

    }



}
