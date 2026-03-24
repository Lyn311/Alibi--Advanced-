using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI itemInfoText;

    [Header("User Interface Display")]
    public CanvasGroup evidencePanelGroup;
    public RectTransform panelRect;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;

    [Header("UI Animation")]
    public float transitionalSpd = 5f;
    public Vector2 hiddenPos = new Vector2(500,0);
    public Vector2 visiblePos = new Vector2(50, 0);

    private bool isPanelVisible = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            
        }

        evidencePanelGroup.alpha = 0f;
        panelRect.anchoredPosition = hiddenPos;


    }

    void Update()
    {
        float targetAlpha = isPanelVisible ? 1f : 0f;
        evidencePanelGroup.alpha = Mathf.Lerp(evidencePanelGroup.alpha, targetAlpha, transitionalSpd * Time.deltaTime);

        Vector2 targetPos = isPanelVisible ? visiblePos : hiddenPos;
        panelRect.anchoredPosition = Vector2.Lerp(panelRect.anchoredPosition, targetPos, transitionalSpd * Time.deltaTime);

    }




    public void ItemInfoDisplay(ItemInfo _info)
    {
        itemNameText.text = _info.itemName;
        itemDescriptionText.text = _info.description;

        if(_info.type == ItemType.Report)
        {
            visiblePos = new Vector2(0,100);

        }
        else
        {

            visiblePos = new Vector2(180, 0);
        }


            isPanelVisible = true;

    }

    public void CloseDisplay()
    {
        isPanelVisible = false;
    }

}
