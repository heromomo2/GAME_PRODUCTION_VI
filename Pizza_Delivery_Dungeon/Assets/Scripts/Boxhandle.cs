using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxhandle : MonoBehaviour
{
    public GameObject _pizzabox;

    public List<GameObject> _pizzboxlist;

    public int _generatenumber = 6;
    public int _generatenumbercounter = 0;

    public Transform _holdpoint;

    public bool _callonce = false;
    public bool _callonce1 = false;

    GameObject _prevpizza = null;
    GameObject _newpizza = null;

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
            // GenerateDeliverlyBox();
            print(" GenerateDeliverlyBoxes()  been call from update ");

            StartCoroutine(StartGenerateDeliverlyBoxes());

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

    void GenerateDeliverlyBox()
    {


        print("_pizzboxlist.Count != 0 ");

        if (_pizzabox != null && _holdpoint != null)
        {
            print("_pizzabox != null && _holdpoint  != null");


            if (_newpizza == null)
            {
                _newpizza = Instantiate(_pizzabox, new Vector3(_holdpoint.transform.position.x, _holdpoint.transform.position.y + 0.2f, _holdpoint.transform.position.z), Quaternion.identity);
                _pizzboxlist.Add(_newpizza);
                // _newpizza.GetComponent<FixedJoint>().connectedBody = _holdpoint.GetComponent<Rigidbody>();
                _newpizza.transform.parent = _holdpoint.transform;
                _prevpizza = _newpizza;

            }
            else
            {
                _newpizza = Instantiate(_pizzabox, new Vector3(_prevpizza.transform.position.x, _prevpizza.transform.position.y + 0.1f, _prevpizza.transform.position.z), Quaternion.identity);
                _pizzboxlist.Add(_newpizza);
                // _newpizza.GetComponent<FixedJoint>().connectedBody = _prevpizza.GetComponent<Rigidbody>();
                _newpizza.transform.parent = _prevpizza.transform;
                _prevpizza = _newpizza;
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
        _prevpizza = null;
        _newpizza = null;
    }
    void AddDeliverlyBox()
    {

    }

    IEnumerator StartGenerateDeliverlyBoxes()
    {
        yield return new WaitForSeconds(0.5f);
        if (_generatenumbercounter < _generatenumber)
        {
            _generatenumbercounter = _generatenumbercounter + 1;
            GenerateDeliverlyBox();

            StartCoroutine(StartGenerateDeliverlyBoxes());

        }

    }
}
