using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteDisplay : MonoBehaviour
{
    private List<Vector3> _waypoints;
    private LineRenderer m_lineRenderer;
    
    public List<Vector3> Waypoints
    {
        get { return _waypoints; }
        set
        {
            m_lineRenderer = GetComponent<LineRenderer>();
            _waypoints = value;
            if (_waypoints != null && _waypoints.Count > 1)
            {
                m_lineRenderer.positionCount = _waypoints.Count;
                for (int i = 0; i < _waypoints.Count; i++)
                {
                    m_lineRenderer.SetPosition(i, _waypoints[i]);
                }
            }
            else
            {
                m_lineRenderer.positionCount = 0;
            }
        }
    }

    public RouteDisplay()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
