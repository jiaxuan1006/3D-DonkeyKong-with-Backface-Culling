using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fire : MonoBehaviour
{
    public float turnInterval = 3f;
    public float Thrust = 10f;
    private int numGen = 0;
    private int counter = 0;
    private Vector3 direction = new Vector3(0, 90, 0);
    //private float direction1 = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(turn());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().eulerAngles = direction;
        GetComponent<Rigidbody>().velocity = transform.forward * 6;
        //transform.position = new Vector3( transform.position.x + direction1, transform.position.y, transform.position.z );
        //transform.position.x = transform.position.x + 0.1 * direction1;

       if (counter == 2)
            {
                transform.position = new Vector3( transform.position.x, transform.position.y + 6, transform.position.z + 4.1f);
                counter = 0;
            }
        
    }

    private IEnumerator turn()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnInterval);
            numGen = Random.Range(1, 100);
            Debug.Log("in");
            if (numGen >= 1 && numGen <= 50)
            {
                direction = new Vector3(0, -90, 0);
            }

            else if (numGen >= 51 && numGen <= 100)
            {
                direction = new Vector3(0, 90, 0);
            }            
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "BorderR")
        {
            direction = new Vector3(0, -90, 0);
           
            counter++;
        }

        if (collider.gameObject.name == "BorderL")
        {
            direction = new Vector3(0, 90, 0);
           
            counter++;
        }

        if (collider.name == "hammer")
        {
            Destroy(gameObject);
        }
    }
}
