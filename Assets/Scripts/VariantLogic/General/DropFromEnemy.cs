using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromEnemy : MonoBehaviour
{
    [SerializeField] private SerializableFloatReactiveProperty _healthDropChance = new SerializableFloatReactiveProperty();
    [SerializeField] FirstAidKitGenerator _fak;

    private bool ShouldDropItem(float chance)
    {
        float randomValue = Random.Range(0f, 1f);
        float calculatedChance = chance;
        return randomValue <= calculatedChance;
    }

    public void DropHealthItem(Vector2 pos)
    {
        Debug.Log("Передались в метод координаты " + pos);
        if (ShouldDropItem(_healthDropChance.Value))
        {
            _fak.Generator(pos);
            return;
        }        
    }


}
