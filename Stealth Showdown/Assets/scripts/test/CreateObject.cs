using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject _addObject;
    [SerializeField] private List<GameObject> _objectTT = new List<GameObject>();
    private GameObject _newObj;
    private Transform _camTransform;
    private Transform _dirLight;

    private void Start()
    {
        _camTransform = this.GetComponent<Transform>();
        Debug.Log(_camTransform.localPosition);
        Weapon bow = new Weapon("bow",2);
        Paladin hero = new Paladin("Alex",bow);
        hero.CharacterInfo();

        _dirLight = GameObject.Find("Global Light 2D").GetComponent<Transform>();
        _dirLight.localPosition = new Vector3(0,10,0);
        Debug.Log(_dirLight.localPosition);
        //_newObj = Instantiate(_object, new Vector2(8,5), Quaternion.Euler(new Vector3(0f,0f,0f))) as GameObject;
        /* Dictionary<string,int> itemInvetory = new Dictionary<string, int>() // создание словар€
         {
             {"FlashLight",1 }, // ключ - значение
             {"Pistol",2 },
         };
         int gold = 2;
         itemInvetory.Add("Knife", 3);
         // проверка на наличии значени€ в словаре
         if (itemInvetory.ContainsKey("FlashLight"))
         {
             Debug.Log("true");
         }
         else
         {
             Debug.Log("false");
         }
         foreach(KeyValuePair<string,int> pair in itemInvetory)
         {
             if (gold >= pair.Value)
             {
                 Debug.LogFormat("{0} = {1}", pair.Key, pair.Value + "ћогу позволить");
             }
             else {
                 Debug.LogFormat("{0} = {1}", pair.Key, pair.Value + "Ќе могу позволить");
             }
         }
         Debug.Log(itemInvetory.Count);*/

    }

    private void Create()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(_objectTT[UnityEngine.Random.Range(0, _objectTT.Count)], new Vector2(RandomVector(), RandomVector()), Quaternion.Euler(new Vector2(0, 0)));
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

    private IEnumerator CreateObjects(float wait)
    {
        int count = 0;
        //yield return new WaitForSeconds(wait); // ждЄм 3 секунды потом выполн€ем то что идем дальше 
        // Create();
        while (true) {
            Instantiate(_objectTT[UnityEngine.Random.Range(0, _objectTT.Count)], new Vector2(RandomVector(), RandomVector()), Quaternion.Euler(new Vector2(0, 0)));
            count++;
            if (count == 5) {
                _objectTT.Add(_addObject);
            }
            yield return new WaitForSeconds(wait);
        }
    }
}
