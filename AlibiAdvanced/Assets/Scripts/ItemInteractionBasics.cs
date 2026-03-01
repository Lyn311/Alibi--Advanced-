using UnityEngine;

public class ItemInteractionBasics : MonoBehaviour
{
    public ItemInfo itemInfo;

    private Vector3 _offset;
    private float _ZSets;
    protected bool isDragging = false;



    public void OnMouseDown()
    {
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
        transform.position = GetMouseWorldPos() + _offset;
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
    }


    public virtual void InspectItem()
    {
       UIManager.Instance.ItemInfoDisplay(itemInfo);
       Debug.Log($"Inspecting {itemInfo.itemName}");

    }



}
