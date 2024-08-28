using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public ScoreManager score;
    public GameObject Fire;

    public bool isScore = false;

    // Start is called before the first frame update
    void Start()
    {
        if (name != "SpawnBarrel" )
        {
            GetComponent<Rigidbody>().velocity = new Vector3(16, 0, 0);
        }

        else if (name == "SpawnBarrel" )
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "OilBarrel")
        {
            Destroy(gameObject);
            GameObject fireClone = Instantiate(Fire, Fire.transform.position , Fire.transform.rotation);
            fireClone.SetActive(true);
        }

        if (collider.name == "hammer")
        {
            score.addScore(150);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BorderR")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
            transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z - 4.1f);
        }

        if (collision.gameObject.name == "BorderL")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
            transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z - 4.1f);
        }
    }
}
