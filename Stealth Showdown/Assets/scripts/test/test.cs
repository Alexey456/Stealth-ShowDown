using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObjects = new GameObject[3];
    [SerializeField] Transform[] _Transforms = new Transform[3];

    private float _speed,_rotateSpeed;
    private void Start()
    {
        _speed = 1f;
        _rotateSpeed = 10f;
    }
    private void Update()
    {
        MoveObj();
    }

    private void MoveObj()
    {
        for (int i = 0; i < _Transforms.Length; i++)
        {
            if (_Transforms[i] == null)
                continue;

            _Transforms[i].Translate(new Vector2(1,0) * (_speed * Time.deltaTime));
            _Transforms[i].Rotate(new Vector2(-1,0) * (_rotateSpeed * Time.deltaTime));

            float posX = _Transforms[i].position.x;
            Debug.Log(_Transforms[i].gameObject.name  + " === "+ posX);
            if (posX > 5.0f)
                Destroy(_Transforms[i].gameObject);
        }
    }
}
