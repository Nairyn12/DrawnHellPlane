using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GenerationAsteroids : MonoBehaviour
{
    [SerializeField] private List<GameObject> _asteroids;
    [SerializeField] private Transform _destroyer;
    
    [SerializeField] private float speedGeneration;

    void Start()
    {
        StartCoroutine(GeneratorStart());
    }

    public void Generation()
    {
        int r = Random.Range(0, _asteroids.Count);
        float p = Random.Range(-9.0f, 9.0f);
        float f = Random.Range(-12.0f, 12.0f);

        if (_asteroids.Count > 0)
        {
            _asteroids[r].SetActive(true);
            _asteroids[r].transform.position = new Vector2(transform.position.x + p, transform.position.y);
            Vector3 direction = new Vector2(_destroyer.position.x + f, _destroyer.position.y);
            _asteroids[r].GetComponent<Rigidbody2D>().AddForce(direction - _asteroids[r].transform.position, ForceMode2D.Impulse);
            _asteroids.RemoveAt(r);
        }
    }

    public void ReturnOnList(GameObject ast)
    {
        bool overlap = false;

        for (int i = 0; i < _asteroids.Count; i++)
        {
            if (_asteroids[i].name == ast.name)
            {
                overlap = true;
            }
        }

        if (!overlap)
        {
            ast.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ast.transform.position = transform.position;
            _asteroids.Add(ast);
            ast.SetActive(false);
        }
    }

    IEnumerator GeneratorStart()
    {
        float r = Random.Range(0.5f, 2.0f);

        yield return new WaitForSeconds(speedGeneration + r);

        Generation();
        StartCoroutine(GeneratorTemp());
    }

   IEnumerator GeneratorTemp()
    {
        float r = Random.Range(0.5f, 2.0f);

        yield return new WaitForSeconds(speedGeneration + r);

        Generation();
        StartCoroutine(GeneratorTemp());
    }


}
