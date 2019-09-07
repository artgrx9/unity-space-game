using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour
{
    public Transform ObjectToSpawn;
    public Transform LeftLimit;
    public Transform RightLimit;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0 ,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(ObjectToSpawn,
            gameObject.transform.position,
            Quaternion.identity);

        Vector3 newPosition = gameObject.transform.position;
        newPosition.x = Random.Range(LeftLimit.position.x,
            RightLimit.position.x);
        gameObject.transform.position = newPosition;
    }
}
