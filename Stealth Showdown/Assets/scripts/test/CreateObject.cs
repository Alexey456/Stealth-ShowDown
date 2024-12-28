using UnityEngine;
using System;
using System.Collections;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _object;
    private GameObject _newObj;

    private void Start()
    {
        //_newObj = Instantiate(_object, new Vector2(8,5), Quaternion.Euler(new Vector3(0f,0f,0f))) as GameObject;
        
    }

    private void Create()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(_object[UnityEngine.Random.Range(0, _object.Length)], new Vector2(RandomVector(), RandomVector()), Quaternion.Euler(new Vector2(0, 0)));
        }
    }
    private void Update()
    {
        //_newObj.GetComponent<Transform>().Translate(new Vector2(-1, -1) * 5f * Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.Q))
        {
            StartCoroutine(CreateObjects(2f));
        }
    }

    private float RandomVector()
    {
        return UnityEngine.Random.Range(0.0f, 10.0f);
    }

    private IEnumerator CreateObjects( float wait)
    {
        //yield return new WaitForSeconds(wait); // ждём 3 секунды потом выполняем то что идем дальше 
        // Create();
        while (true) {
            Instantiate(_object[UnityEngine.Random.Range(0, _object.Length)], new Vector2(RandomVector(), RandomVector()), Quaternion.Euler(new Vector2(0, 0)));
            yield return new WaitForSeconds(wait);
        }
    }
}
