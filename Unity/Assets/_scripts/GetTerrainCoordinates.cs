using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTerrainCoordinates : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("Terrain")))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
                Debug.Log(hit.point);
                
                Instantiate(Character, hit.point, hit.transform.rotation);
            }
        }
        
    }

    public GameObject Character;
    

}
