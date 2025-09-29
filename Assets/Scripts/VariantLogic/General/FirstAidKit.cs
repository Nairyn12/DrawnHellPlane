using UnityEngine;
using UnityEngine.Events;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private SerializableFloatReactiveProperty _healthAmount = new SerializableFloatReactiveProperty();
    public UnityEvent _return;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<HealthSystem>() && !col.gameObject.CompareTag("ProtectiveField"))
        {
            col.gameObject.GetComponent<HealthSystem>().Heal(_healthAmount.Value);
            gameObject.SetActive(false);
            _return?.Invoke();
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            gameObject.SetActive(false);
            _return?.Invoke();
        }
    }
}
