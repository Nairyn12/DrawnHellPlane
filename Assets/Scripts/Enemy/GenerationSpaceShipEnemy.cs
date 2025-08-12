using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSpaceShipEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spaceShips;
    [SerializeField] private Transform _destroyer;

    [SerializeField] private float speedGeneration;

    void Start()
    {
        StartCoroutine(GeneratorSpaceEnemyStart());
    }

    public void Generation()
    {
        int r = Random.Range(0, _spaceShips.Count);
        float p = Random.Range(-9.0f, 9.0f);
        float f = Random.Range(-12.0f, 12.0f);

        if (_spaceShips.Count > 0)
        {
            _spaceShips[r].SetActive(true);
            _spaceShips[r].transform.position = new Vector2(transform.position.x + p, transform.position.y);
            Vector3 direction = new Vector2(_destroyer.position.x + f, _destroyer.position.y);
            _spaceShips[r].GetComponent<Rigidbody2D>().AddForce((direction - _spaceShips[r].transform.position)*0.2f, ForceMode2D.Impulse);
            StartCoroutine(_spaceShips[r].GetComponent<ShootingSpaceShipEnemys>().Shooting());
            _spaceShips[r].GetComponent<SpaceShipEnemyMove>().MoveEnemyShips();
            _spaceShips.RemoveAt(r);
        }
    }

    public void ReturnOnList(GameObject space)
    {
        bool overlap = false;

        for (int i = 0; i < _spaceShips.Count; i++)
        {
            if (_spaceShips[i].name == space.name)
            {
                overlap = true;
            }
        }

        if (!overlap)
        {
            Debug.Log(space.name + " возврат в пул");
            space.transform.position = transform.position;
            Health health = space.GetComponent<Health>();
            health.Healing(health.HealthMax);
            health.IsPlayerDestroy = false;
            space.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _spaceShips.Add(space);
            space.SetActive(false);
        }
    }


    IEnumerator GeneratorSpaceEnemyStart()
    {
        float r = Random.Range(0.5f, 2.0f);

        yield return new WaitForSeconds(speedGeneration + r);

        Generation();
        StartCoroutine(GeneratorSpaceEnemyTemp());
    }

    IEnumerator GeneratorSpaceEnemyTemp()
    {
        float r = Random.Range(0.5f, 2.0f);

        yield return new WaitForSeconds(speedGeneration + r);

        Generation();
        StartCoroutine(GeneratorSpaceEnemyTemp());
    }


}
