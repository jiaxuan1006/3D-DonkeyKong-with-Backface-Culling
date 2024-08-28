using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{
    public GameObject barrelObj;
    public float spawnInterval = 4f; // Time interval between barrel spawns
    

    private void Start()
    {
        GameObject barrelClone = Instantiate(barrelObj, barrelObj.transform.position, barrelObj.transform.rotation);
        barrelClone.SetActive(true);
        StartCoroutine(SpawnBarrels());
    }

    private IEnumerator SpawnBarrels()
    {
        while (true) // Keep spawning barrels indefinitely
        {
            yield return new WaitForSeconds(spawnInterval);

            // Instantiate a new barrel at the desired position and rotation
            GameObject barrelClone = Instantiate(barrelObj, barrelObj.transform.position, barrelObj.transform.rotation);
            barrelClone.SetActive(true);
        }
    }
}

