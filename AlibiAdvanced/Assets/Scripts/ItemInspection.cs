using UnityEngine;

namespace Alibi.Inspections
{
    [RequireComponent(typeof(Animator))]
    public class ItemInspection : MonoBehaviour
    {
        [Header("Initials")]
        public LayerMask itemLayer;

        private Animator itemAnimator;
        private Camera mainCamera01;

        private static readonly int IsInspecting = Animator.StringToHash("IsInspecting");

        void Start()
        {
            itemAnimator = GetComponent<Animator>();
            mainCamera01 = Camera.main;

        }

     
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RayCastInitate();


            }
        }


        private void RayCastInitate()
        {
            RaycastHit hit;

            Ray ray = mainCamera01.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, itemLayer))
            {
                if (hit.transform == transform)
                {
                    itemAnimator.SetBool(IsInspecting, true);
                }
                else
                {
                    CancelInspection();
                }
            }
            else
            {
                CancelInspection();
            }


        }

        private void CancelInspection()
        {

            itemAnimator.SetBool(IsInspecting, false);



        }






    }

}