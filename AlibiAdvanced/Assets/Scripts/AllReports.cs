using UnityEngine;

public class AllReports : ItemInteractionBasics
{
    public override void InspectItem()
    {
        base.InspectItem();
        Debug.Log("This is a report that contains all the information about the case.");
    }




}
