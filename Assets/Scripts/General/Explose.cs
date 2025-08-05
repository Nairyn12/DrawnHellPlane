using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Explose : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    public void SetExplosion(int scale, Vector2 pos)
    {
        GameObject explosion = Instantiate(_explosion, pos, Quaternion.identity);
        explosion.transform.localScale *= scale;
        StartCoroutine(ExploseDuration(explosion));
    }

    IEnumerator ExploseDuration(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
    }
}
