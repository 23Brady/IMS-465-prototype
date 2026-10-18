using System.Collections;
using UnityEngine;

public class Graze : MonoBehaviour
{
    [SerializeField] private TPUI TPBar;
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
            TPBar.SetTP(25.0f);
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
