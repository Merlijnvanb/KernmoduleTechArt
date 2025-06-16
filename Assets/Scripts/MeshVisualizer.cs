using UnityEngine;

[ExecuteInEditMode]
public class WireframeSpawner : MonoBehaviour
{
    public Mesh Mesh;
    public Material Material;
    public int SubdivisionLevel;

    private Mesh subdividedMesh;
    private GameObject spawnedObject;

    void Start()
    {
        subdividedMesh = Instantiate(Mesh);
        MeshHelper.Subdivide(subdividedMesh, SubdivisionLevel);

        SpawnGO();
    }

    private void SpawnGO()
    {
        spawnedObject = new GameObject("VisualizedMesh");
        spawnedObject.transform.SetParent(transform, false);
        
        var meshFilter = spawnedObject.AddComponent<MeshFilter>();
        meshFilter.mesh = subdividedMesh;
        
        var meshRenderer = spawnedObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = Material;
    }
}