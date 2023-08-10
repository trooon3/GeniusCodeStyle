using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private int _indexInArray;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i).GetComponent<Transform>();
        } 
    }
    
    private void Update()
    {
        var _pointByNumberInArray = _points[_indexInArray];
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position)
        { 
            NextPlaceTakerLogic(); 
        }
    }

    public Vector3 NextPlaceTakerLogic()
    {
        _indexInArray++;

        if (_indexInArray == _points.Length)
        {
            _indexInArray = 0;
        }
            
        var currentPointPosition = _points[_indexInArray].transform.position;
        transform.forward = currentPointPosition + transform.position;
        return currentPointPosition;
    }
}