using UnityEngine;

public class Task2 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _dst;
    [SerializeField] private Transform[] _cars;
    private Vector3 _currentCar;
    private Vector3 _targetCar;
    private int _carIndex;

    private void Start()
    {
        _carIndex = 0;
    }

    private void Update()
    {
        _currentCar = _cars[_carIndex].position;
        _targetCar = _cars[_carIndex + 1].position;
        _cars[_carIndex].LookAt(_cars[_carIndex + 1]);

        if (_carIndex < _cars.Length - 1)
        {
            _cars[_carIndex].transform.position = Vector3.MoveTowards(_currentCar, _targetCar, Time.deltaTime * _speed);

            if (Vector3.Distance(_currentCar, _targetCar) < _dst)
            {
                _carIndex++;
            }
        }
        if(_carIndex >= _cars.Length - 1)
        {
            _carIndex = 0;
        }
    }
}
