using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        Vector3 p0 = new Vector3(-1, 0, .5f);
        Vector3 p1 = new Vector3(1, 0, .5f);
        Vector3 p2 = new Vector3(-1, 0, -.5f);
        Vector3 p3 = new Vector3(1, 0, -.5f);
        Vector3 p4 = new Vector3(0, 1, .5f);
        Vector3 p5 = new Vector3(0, 1, -.5f);
        Mesh mesh = meshFilter.mesh;
        mesh.Clear();

        mesh.vertices = new Vector3[]{
            p3,p0,p2,
            p1,p0,p3,
            p2,p4,p5,
            p0,p4,p2,
            p3,p5,p4,
            p3,p4,p1,
            p2,p5,p3,
            p1,p4,p0
        };
        mesh.triangles = new int[]{
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11,
            12,13,14,
            15,16,17,
            18,19,20,
            21,22,23
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
