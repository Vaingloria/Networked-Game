using UnityEngine;
using Unity.Netcode;

public class SpawnPackets : NetworkBehaviour
{

    private float spawnTime;
    private float timeSinceLastSpawn;
    public GameObject packet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Random.Range(15f, 45f);
        timeSinceLastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time - timeSinceLastSpawn > spawnTime)
        {
            timeSinceLastSpawn = Time.time;
            spawnTime = Random.Range(30f, 60f);
            PacketSpawningServerRpc(gameObject.transform.position, gameObject.transform.rotation);
        }
    }



    // need to add the [ServerRPC] attribute
    [ServerRpc]
    // method name must end with ServerRPC
    private void PacketSpawningServerRpc(Vector3 position, Quaternion rotation)
    {
        // call the BulletSpawningClientRpc method to locally create the bullet on all clients
        PacketSpawningClientRpc(position, rotation);
    }

    [ClientRpc]
    private void PacketSpawningClientRpc(Vector3 position, Quaternion rotation)
    {
        GameObject newPacket = Instantiate(packet, position, rotation);
        newPacket.GetComponent<NetworkObject>().Spawn(true);
    }
}
