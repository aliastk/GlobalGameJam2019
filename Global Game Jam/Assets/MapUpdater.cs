using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MapUpdater : MonoBehaviour {
    private NavMeshSurface map;
	// Use this for initialization
	void Start () {
        map = GetComponent<NavMeshSurface>();
        StartCoroutine("MapUpdate");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MapUpdate()
    {
        for(; ;)
        {
            yield return new WaitForSeconds(.1f);
            map.UpdateNavMesh(map.navMeshData);
        }
    }
}
