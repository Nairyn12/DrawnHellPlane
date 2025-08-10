using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private TMP_Text _score;

    public void FinalPanelActive()
    {
        StartCoroutine(DelayBeforeFinalPanelActive());
    }

    public void TimeScaleRestar()
    {
        Time.timeScale = 1.0f;
    }

    IEnumerator DelayBeforeFinalPanelActive()
    {
        yield return new WaitForSeconds(1.3f);
        _finalPanel.SetActive(true);
        _score.text = "Scotre: " + ScoreCount.Instance.Score;
        Time.timeScale = 0.0f;
    }
}
