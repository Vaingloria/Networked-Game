using UnityEngine;
using Unity.Netcode;
/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class SimpleGrabSystem : NetworkBehaviour
{
    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;

    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;

    // Reference to the currently held item.
    private PickableItem pickedItem;
    public PlayerMovement movement;


    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetButtonDown("Fire1"))
        {

            if (!IsOwner) return;
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
                pickedItem = null;
                // allow player to jump
                movement.setHolding(false, null);
            }
            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 8.5f))
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<PickableItem>();

                    // If object has PickableItem class
                    if (pickable)
                    {
                        // Pick it
                        PickItem(pickable);
                        // disable jumping
                        movement.setHolding(true, pickable);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Method for picking up item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;

        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.linearVelocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        if (item.slot != null)
        {
            // item being held by someone else, remove from their slot
            item.player.holdingItem = false;
            item.player.myItem = null;
            item.slot = null;
        }
        // Set Slot as a parent
        item.setSlot(slot);
        item.setPickedServerRPC(slot.position);
        

        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

    }



    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        // Remove parent
        item.setSlot(null);
        item.setPickedServerRPC(new Vector3(-1,-1,-1));

        // Enable rigidbody
        item.Rb.isKinematic = false;

        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}