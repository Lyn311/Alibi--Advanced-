using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteractionBasics : MonoBehaviour
{
    public ItemInfo itemInfo;

    private Vector3 _offset;
    private float _ZSets;
    protected bool isDragging = false;

    private Vector3 _originalPos;
    private Quaternion _originalRot;
    private bool isInspecting = false;

    public float smoothSpeed = 10f;

    void Start()
    {
        _originalPos = transform.position;
        _originalRot = transform.rotation;
    }

    public void OnMouseDown()
    {
        if(isInspecting) return;

        _ZSets = Camera.main.WorldToScreenPoint(transform.position).z;
       _offset = transform.position - GetMouseWorldPos();

       isDragging = true;       

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _ZSets;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    public void OnMouseDrag()
    {
        if (isInspecting) return;

        transform.position = GetMouseWorldPos() + _offset;

        _originalPos = transform.position;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    InspectItem();
                }
            }


        }

        InspectionMovement();
    }

    private void InspectionMovement()
    {
        if (isInspecting)
        {
            Vector3 localOffset = (itemInfo.type == ItemType.Evidence) ? new Vector3(-1f,0,2.7f) : new Vector3 (0,0,2.7f);

            Vector3 targetPosition = Camera.main.transform.TransformPoint(localOffset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            Quaternion targetRot = Camera.main.transform.rotation * Quaternion.Euler(90f, 0f, 180f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, smoothSpeed * Time.deltaTime);
            
        }
        else if(!isDragging)
        {
            transform.position = Vector3.Lerp(transform.position, _originalPos, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _originalRot, smoothSpeed * Time.deltaTime);
        }



    }

    public virtual void InspectItem()
    {
        if(!isInspecting && PanelManager.Instance.IsPanelOpen)
        {
            Debug.Log("Cannot inspect item while panel is open.");
            return;
        }

        isInspecting = !isInspecting;

        if (isInspecting) { 

        UIManager.Instance.ItemInfoDisplay(itemInfo);
        Debug.Log($"Inspecting {itemInfo.itemName}");
        PanelManager.Instance.triggerPanelOpen(true);

        }
        else
        {
            UIManager.Instance.CloseDisplay();
            PanelManager.Instance.triggerPanelOpen(false);

        }

    }



}
