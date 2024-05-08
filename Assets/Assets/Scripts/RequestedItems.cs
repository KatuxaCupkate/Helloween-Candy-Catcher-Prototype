using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;
using System.Diagnostics.CodeAnalysis;


public class RequestedItems : MonoBehaviour
{

    [SerializeField, Range(1f, 10f)] int _maxReqCandiesAmount;
    [SerializeField] private GameObject[] _reqCandys;
    [SerializeField] private GameObject[] _placeToSetCandy;
    [SerializeField] public TextMeshProUGUI[] _candiesAmountText;

    private GameObject CandyToSet;
    private int AmountToCollect;
    public  Dictionary<GameObject, int> _placedCandys;



    // Start is called before the first frame update
    void Start()
    {
        _placedCandys = new Dictionary<GameObject, int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowRequiredCandys();
            ShowRequiredAmount();

        }

        if (Input.GetMouseButtonDown(1))
        {
            CleanUpCandyRequest();
        }
    }

    private void ShowRequiredCandys()
    {
        for (int i = 0; i < _placeToSetCandy.Length; i++)
        {
            _placedCandys.Add((Instantiate(SetRandomCandy(), PositionForCandy(i), _placeToSetCandy[i].transform.rotation)), SetRandomAmount());
        }
        EventManager.RequirementsSetEvent(_placedCandys);
    }
    private void ShowRequiredAmount()
    {

        for (int i = 0; i < _candiesAmountText.Length; )
        {
            foreach (KeyValuePair<GameObject, int> kvp in _placedCandys)
            {
                _candiesAmountText[i].text = kvp.Value.ToString();
                i++;
            }
        }

    }
    public void CleanUpCandyRequest()
    {
        foreach (KeyValuePair<GameObject, int> kvp in _placedCandys)
        {
            Destroy(kvp.Key);
        }
        _placedCandys.Clear();
        EventManager.RequirementsRemovedEvent();
    }

    GameObject SetRandomCandy()
    {

        GameObject setCandy = _reqCandys[Random.Range(0, _reqCandys.Length)];
        return setCandy;
    }

    Vector3 PositionForCandy(int index)
    {
        Vector3 posForCandy = new Vector3(_placeToSetCandy[index].transform.position.x, _placeToSetCandy[index].transform.position.y, _placeToSetCandy[index].transform.position.z);
        return posForCandy;
    }
    
    public int SetRandomAmount()
    {
        AmountToCollect = Random.Range(1, _maxReqCandiesAmount);
        return AmountToCollect;
    }

}
