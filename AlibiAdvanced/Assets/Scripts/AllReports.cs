using UnityEngine;

public class AllReports : ItemInteractionBasics
{
    public override void InspectItem()
    {
        base.InspectItem();
        Debug.Log("VICTIM REPORT");
    }




}
