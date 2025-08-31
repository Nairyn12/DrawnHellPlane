using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fakPool;

    public void Generator(Vector2 position)
    {
       if (_fakPool.Count>0)
        {
            _fakPool[0].transform.position = new Vector2(position.x, position.y); ;
            _fakPool[0].SetActive(true);
            Debug.Log(_fakPool[0].name + " " + _fakPool[0].transform.position + " ---------");
            _fakPool.RemoveAt(0);
        }
    }

    public void ReturnToPool(GameObject fak)
    {
        bool overlap = false;

        for (int i = 0; i < _fakPool.Count; i++)
        {
            if (_fakPool[i].name == fak.name)
            {
                overlap = true;
            }
        }

        if (!overlap)
        {
            fak.transform.position = transform.position;
            fak.SetActive(false);
            _fakPool.Add(fak);
        }  
    }
}
