using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private ViewModelPlayer _view;
    [SerializeField] private TMP_Text _HealthText;

    private void Start()
    {
        _view.onChangedHealth += RewriteHealth;
    }

    public void RewriteHealth()
    {
        _HealthText.text = "Health: " + _view.HealthCurrent;
    }


}
