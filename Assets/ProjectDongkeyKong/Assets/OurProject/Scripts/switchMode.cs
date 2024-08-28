using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMode : MonoBehaviour
{
    public Shader defaultShader;
    public Shader backface;
    public Shader frontface;
    public Shader offcull;
    public GameObject parentOfAll;
    Renderer rend;
    private string mode = "-";
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey("1"))
        {
            mode = "1";
            SetShaderRecursive(parentOfAll.transform);
        }

        if (Input.GetKey("2"))
        {
            mode = "2";
            SetShaderRecursive(parentOfAll.transform);
        }

        if (Input.GetKey("3"))
        {
            mode = "3";
            SetShaderRecursive(parentOfAll.transform);
        }

        if (Input.GetKey("4"))
        {
            mode = "4";
            SetShaderRecursive(parentOfAll.transform);
        }
    }

    void SetShaderRecursive(Transform parent)
    {
        Renderer renderer = parent.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (mode == "1")
                renderer.material.shader = defaultShader;
            else if (mode == "2")
                renderer.material.shader = backface;
            else if (mode == "3")
                renderer.material.shader = frontface;
            else if (mode == "4")
                renderer.material.shader = offcull;
        }

        foreach (Transform child in parent)
        {
            SetShaderRecursive(child);
        }
    }
}