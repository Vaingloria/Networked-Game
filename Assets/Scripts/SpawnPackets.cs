using UnityEngine;

public class SpawnPackets : MonoBehaviour
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
            GameObject newPacket = GameObject.Instantiate(packet, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        }
    }
}
