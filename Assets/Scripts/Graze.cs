using System.Collections;
using UnityEngine;

public class Graze : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject ring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<IDamager>(out var damager))
        {
            damager.GainTP();
            ring.SetActive(true);
            StartCoroutine(Hide());
            
        }
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.1f);
        ring.SetActive(false);
    }
}
