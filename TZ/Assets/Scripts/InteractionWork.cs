using UnityEngine;

public class InteractionWork : MonoBehaviour
{
    [SerializeField] private InteractProp _pickUpProp;

    private Vector3 InventoryPosition = new Vector3(0,-100,0);
    private Ray _ray;
    private RaycastHit _raycast;
    private float _rayDistance = 2f;

    private void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(_ray, out _raycast, _rayDistance);

        try
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_raycast.collider.TryGetComponent<InteractProp>(out InteractProp prop) && prop.IsInteract == true && _pickUpProp == null)
                {
                    _pickUpProp = prop;
                    prop.GetComponent<Rigidbody>().isKinematic = true;
                    prop.transform.position = InventoryPosition;
                }

                if (_raycast.collider.TryGetComponent<Bag>(out Bag bag) && _pickUpProp != null)
                {
                    bag.AddProp(_pickUpProp);
                    _pickUpProp = null;
                }
            }
        }
        catch{}
    }
}
