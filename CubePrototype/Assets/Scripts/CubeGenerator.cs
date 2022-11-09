using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

 [SerializeField] [Range(0, 1)] float xSize;
[SerializeField] [Range(0, 1)]float ySize;
 [SerializeField] [Range(0, 1)]float zSize;
    [SerializeField] Material myMaterial;

[SerializeField] [Range(0, 20)]float animationSpeed;
MeshFilter myMeshFilter;
MeshRenderer myRenderer;

void Start()
{
    //ADD a renderer to display the cube/mesh
    myRenderer =  gameObject.AddComponent<MeshRenderer>();
    // ADD a mshfilter to assign the mesh to the gameobject 
    myMeshFilter = gameObject.AddComponent<MeshFilter>();   
    //Call generate Cube to create a cube mesh
   
    myRenderer.material = myMaterial;

    
}



Mesh GenerateCube(float x, float y, float z)
{
    //create a new empty mesh object
    Mesh myMesh = new Mesh();

    myMesh.RecalculateNormals();

    //initialize and fill vertices array containing all vertices of the cube
     Vector3[] myVertices = new Vector3[8]
     {
        new Vector3(0,0,0), // 0
        new Vector3(0,y,0), // 1
        new Vector3(x,y,0), // 2
        new Vector3(x,0,0), // 3
        new Vector3(0,0,z), // 4
        new Vector3(0,y,x), // 5
        new Vector3(x,y,z), // 6
        new Vector3(x,0,z)  // 7
     };

    //assign vertices to mesh
    myMesh.vertices = myVertices;

    //create int arry containing indices to build triangles in the mesh
    int[] myTriangles = new int[36]
    {
        // Back
        0,1,2,
        2,3,0,
        // Right
        3,2,6,
        6,7,3,
        // Up
        2,1,6,
        6,1,5,
        // Front
        7,5,4,
        7,6,5,
        // Left
        5,1,0,
        0,4,5,
        // Down
        0,3,4,
        3,7,4
    };

    //assign trangle array to mesh
    myMesh.triangles = myTriangles;

    myMesh.RecalculateNormals();
    //assign mesh to meshfilter
   //myMeshFilter.mesh = myMesh;

    //
    return myMesh;
}

 void Update()
 {
    float animY = (Mathf.Sin(Time.time + 1 * animationSpeed) / 2) * ySize;
    myMeshFilter.mesh = GenerateCube(xSize, animY, zSize);
 }
}
