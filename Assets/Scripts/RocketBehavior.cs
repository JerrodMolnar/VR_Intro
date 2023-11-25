using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _timer = 4f;
    [SerializeField] GameObject _explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        transform.Rotate(Vector3.right * 25);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(_timer);
        DestroyThisWithExplosion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target") || other.CompareTag("Ground"))
            DestroyThisWithExplosion();
    }

    void DestroyThisWithExplosion()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
