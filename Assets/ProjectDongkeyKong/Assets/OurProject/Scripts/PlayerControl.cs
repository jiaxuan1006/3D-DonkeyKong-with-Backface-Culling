using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private string midJump = "n";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("a"))&& (midJump == "n"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, -90, 0);

        }

        if ((Input.GetKey("d"))&& (midJump == "n"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);

        }

        if ((!Input.GetKey("a"))&& (!Input.GetKey("d")) && (midJump == "n"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().Play("Idle");
        }

        else if (midJump == "n")
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 4;
            GetComponent<Animator>().Play("Walk");
        }

        if (Input.GetKeyDown("space"))
        {
             GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 6, 0);
             GetComponent<Animator>().Play("Jump");
             midJump = "y";

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="girder")
        {
            midJump = "n";
        }
    }
}
