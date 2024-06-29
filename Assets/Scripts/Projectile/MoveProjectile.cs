using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    [SerializeField] private float Speed;

    private void OnEnable()
    {
        StartCoroutine(DeactivateObject());
    }
    private void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(5f);
        ObjectPoolingManager.ReturnGameObjectToPool(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<OnPlayerDamaged>().damagePlayer(1);
        }
    }
}
