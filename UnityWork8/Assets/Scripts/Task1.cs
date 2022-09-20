using UnityEngine;

public class Task1 : MonoBehaviour
{
    [SerializeField] Vector3[] _flags;
    [SerializeField] Transform[] _cars;
    [SerializeField] private float _speed;
    [SerializeField] private float _dst;
    private bool _go;
    private int _count;

    private void Start()
    {
        _count = 0;
        _go = true;
        _flags[0] = _cars[0].position;
        _flags[1] = _cars[1].position;
        _flags[2] = _cars[2].position;
    }

    private void Update()
    {

        if (_go == true && _count < _flags.Length)
        {
            transform.LookAt(_flags[_count]);
            transform.position = Vector3.MoveTowards(transform.position, _flags[_count], Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _flags[_count]) < _dst)
            {
                _count++;
            }
        }
        if (_count >= _flags.Length)
        {
            _count = _flags.Length;
            _go = false;
        }
        if (_go == false && _count <= _flags.Length)
        {
            transform.LookAt(_flags[_count - 1]);
            transform.position = Vector3.MoveTowards(transform.position, _flags[_count - 1], Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _flags[_count - 1]) < _dst)
            {
                _count--;
            }
        }
        if (_count <= 0)
        {
            _count = 0;
            _go = true;
        }
    }
}
