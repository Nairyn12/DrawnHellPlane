using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private Button _backBatton;
    [SerializeField] private TMP_Text _score;

    public void FinalPanelActive(bool isDead)
    {
        _finalPanel.SetActive(true);
        _backBatton.interactable = isDead;       
        _score.text = "Scotre: " + ScoreCount.Instance.Score;
        Time.timeScale = 0.0f;
    }

    public void SetPanelAfterDeath(bool isDead)
    {
        StartCoroutine(DelayBeforeFinalPanelActive(isDead));
    }

    public void TimeScaleRestar()
    {
        Time.timeScale = 1.0f;
    }

    IEnumerator DelayBeforeFinalPanelActive(bool isDead)
    {
        yield return new WaitForSeconds(1.3f);
        FinalPanelActive(isDead);
    }
}
