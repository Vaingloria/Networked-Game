using UnityEngine;
using Unity.Netcode;

public class Goal : NetworkBehaviour
{
    public Score ScoreManager;
    private PlayerMovement p;

    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            p = collision.gameObject.GetComponent<PlayerMovement>();
            if (p.holdingItem)
            {
                
                p.holdingItem = false;
                DestroyHeldItemServerRpc();
                UpdateScoreClientRpc();
                p.myItem = null;
            }
        }

        // if the collision is detected destroy the object
        //DestroyTargetServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void DestroyHeldItemServerRpc()
    {
        
        //despawn
        p.myItem.GetComponent<NetworkObject>().Despawn(true);
        //after collision is detected destroy the gameobject
        Destroy(p.myItem);
    }

    [ClientRpc]
    public void UpdateScoreClientRpc()
    { 
        if (p.team == 1)
        {
            ScoreManager.AddPointRed();
        }
        else
        {
            ScoreManager.AddPointBlue();
        }
    }
}
