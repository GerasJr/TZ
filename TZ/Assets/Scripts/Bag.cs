using UnityEngine;
using System.Collections.Generic;

public class Bag : MonoBehaviour
{
    private List<InteractProp> _props = new List<InteractProp>();
    private List<PropPoint> _points = new List<PropPoint>();

    private void Start()
    {
        _points.AddRange(transform.GetComponentsInChildren<PropPoint>());
    }

    public void AddProp(InteractProp prop)
    {
        for(int i = 0; i < _points.Count; i++)
        {
            if(_points[i].IsHaveProp == false)
            {
                _points[i].Add();
                _props.Add(prop);
                prop.transform.position = _points[i].transform.position;
                return;
            }
        }
    }
}
