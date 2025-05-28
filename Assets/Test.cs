using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Mesh mesh;

    void Start()
    {
        for (int i = 0; i < mesh.triangles.Length; i++)
        {
            //Debug.Log(mesh.triangles[i]);
        }
    }
}
