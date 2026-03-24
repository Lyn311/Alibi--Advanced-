using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

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
    }

    private bool isPanelOpen = false;
    public bool IsPanelOpen => isPanelOpen;

    public void triggerPanelOpen(bool toOpen)
    {
        isPanelOpen = toOpen;

    }



}
