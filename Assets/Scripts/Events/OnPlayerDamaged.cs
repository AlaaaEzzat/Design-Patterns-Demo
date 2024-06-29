using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDamaged : Subject
{
    [SerializeField] private float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        UiManager.instance.health = playerHealth;
    }

    public void damagePlayer(int damage)
    {
        if(playerHealth > 0)
        {
            playerHealth -= damage;
            NotifyObservers(EventActions.damaged);
        }
        else
        {
            playerHealth = 0;
        }
    }
}
