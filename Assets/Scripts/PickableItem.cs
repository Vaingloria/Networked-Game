using UnityEngine;
using Unity.Netcode;
/// <summary>
/// Attach this class to make object pickable.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PickableItem : NetworkBehaviour
{
    // Reference to the rigidbody

    private NetworkVariable<Vector3> position = new NetworkVariable<Vector3>(Vector3.zero);
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public bool picked;
    public PlayerMovement player = null;
    public Transform slot = null;
    private Vector3 nullVec;
    private Vector3 myPos;


    /// <summary>
    /// Method called on initialization.
    /// </summary>
    private void Awake()
    {
        // Get reference to the rigidbody
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        picked = false;
        nullVec = new Vector3(-1, -1, -1);
        position.Value = transform.position;

    }

    void Update()
    {
        if(picked)
        {
            //transform.position = position;
            
            if (slot != null)
            {
                updateNetworkVarServerRPC(slot.position);
                updatePosServerRPC(position.Value);
            }
        }
    }

    public void setSlot(Transform s)
    {
        slot = s;
    }

    [ServerRpc (RequireOwnership = false)]
    public void setPickedServerRPC(Vector3 t)
    {
        setPickedClientRPC(t);
    }


    [ClientRpc]
    public void setPickedClientRPC(Vector3 t)
    {
        if (t != nullVec)
        {
            picked = true;
            position.Value = t;
        }
        else
        {
            picked = false;
            //updatePosClientRPC(myPos);
            slot = null;
            myPos = nullVec;
        }
    }


    [Rpc(SendTo.Server)]
    public void updateNetworkVarServerRPC(Vector3 t)
    {
        //updatePosClientRPC(t);
        position.Value = t;
    }

    [Rpc(SendTo.Server)]
    public void updatePosServerRPC(Vector3 t)
    {
        //updatePosClientRPC(t);
        transform.position = t;
    }


    [ClientRpc (RequireOwnership = false) ]
    public void updatePosClientRPC(Vector3 t)
    {
        transform.position = myPos;
    }

}


