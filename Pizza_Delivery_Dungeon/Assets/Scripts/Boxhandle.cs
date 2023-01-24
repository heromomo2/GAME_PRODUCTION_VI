using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxhandle : MonoBehaviour
{
    public GameObject _pizzabox;

    public List<GameObject> _pizzboxlist;

    public int _generatenumber = 6;

    public Transform _holdpoint;

    public bool _callonce = false;
    public bool _callonce1 = false;



    // Start is called before the first frame update
    void Start()
    {
        _pizzboxlist = new List<GameObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (_callonce == true)
        {
            GenerateDeliverlyBoxes();
            print(" GenerateDeliverlyBoxes()  been call from update ");
            _callonce = false;
        }
        else 
        {
            if (_callonce1 == true) 
            {
                DelecteDeliverlyBoxes();
                _callonce1 = false;
            }
        }
    }

    void GenerateDeliverlyBoxes() 
    {
        if (_pizzboxlist.Count < 1) 
        {
            GameObject _newpizza = null;
            GameObject _prevpizza = null;

            print("_pizzboxlist.Count != 0 ");

            if (_pizzabox != null && _holdpoint  != null) 
            {
                print("_pizzabox != null && _holdpoint  != null");

                for (int i = 0; i < _generatenumber; i++)
                {

                    if (_newpizza == null)
                    {
                        _newpizza = Instantiate(_pizzabox, _holdpoint.position, Quaternion.identity);
                        _pizzboxlist.Add(_newpizza);
                        _prevpizza = _newpizza;

                    }
                    else 
                    {
                        _newpizza = Instantiate(_pizzabox, new Vector3 (_prevpizza.transform.position.x, _prevpizza.transform.position.y , _prevpizza.transform.position.z) , Quaternion.identity);
                        _pizzboxlist.Add(_newpizza);
                        _prevpizza = _newpizza;
                    }

                }
            }
        }
    }
    void DelecteDeliverlyBoxes()
    {
        if (_pizzboxlist.Count > 0)
        {
            foreach (GameObject _p in _pizzboxlist)
            {
                DestroyObject(_p);
            }
        }
    }
    void AddDeliverlyBox()
    {

    }
}
