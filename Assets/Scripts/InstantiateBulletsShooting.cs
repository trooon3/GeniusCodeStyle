using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletTarget;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine!=null)
        {
            StopCoroutine(Shooter());
        }

        StartCoroutine(Shooter());
    }

    private IEnumerator Shooter()
    {
        while (true)
        {
            var bulletDirection = (_bulletTarget.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + bulletDirection, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = bulletDirection;
            newBullet.GetComponent<Rigidbody>().velocity = bulletDirection * _speed;

            yield return new WaitForSeconds(_delayBetweenShots);
        }
    }
}