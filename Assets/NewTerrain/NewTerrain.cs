using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class NewTerrain : MonoBehaviour
{
    public int Size = 1;
    public int Resolution = 1;
    public Material Material;
    public Texture2D Heightmap;
    public float HeightmapIntensity = 1.0f;

    public struct TerrainChunk
    {
        
    }
    
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    
    void OnEnable()
    {
        if (meshFilter == null)
        {
            meshFilter = GetComponent<MeshFilter>();
        }

        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        if (meshRenderer.sharedMaterial != Material)
        {
            meshRenderer.sharedMaterial = Material;
        }
        
        GenerateMesh();
    }

    private void GenerateMesh()
    {
        var vertices = new List<Vector3>();
        for (var y = -Size / 2f; y <= Size / 2f; y += (float)Size / Resolution)
        {
            for (var x = -Size / 2f; x <= Size / 2f; x += (float)Size / Resolution)
            {
                var height = Heightmap.GetPixelBilinear((y + Size / 2f) / Size, (x + Size / 2f) / Size);
                vertices.Add(new Vector3(x, height.r * HeightmapIntensity, y));
            }
        }
        
        var triangles = new List<int>();
        for (var col = 0; col < Resolution; col++)
        {
            for (var row = 0; row < Resolution; row++)
            {
                int i = col * (Resolution + 1) + row;

                triangles.Add(i);
                triangles.Add(i + Resolution + 1);
                triangles.Add(i + Resolution + 2);
                
                triangles.Add(i);
                triangles.Add(i + Resolution + 2);
                triangles.Add(i + 1);
            }
        }

        mesh = meshFilter == null ? new Mesh() : meshFilter.sharedMesh;
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.sharedMesh = mesh;
    }
}
