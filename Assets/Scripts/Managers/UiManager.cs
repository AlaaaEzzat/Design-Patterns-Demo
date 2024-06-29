using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour , Iobservers
{
    public static UiManager instance;
    [SerializeField] private Subject s;
    [SerializeField] private TextMeshProUGUI playerHealth;
    public float health {  get; set; }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        s.AddObserver(this);
    }

    private void OnDisable()
    {
        s.RemoveObserver(this);
    }

    private void Update()
    {
        SetPlayerHealth();
    }

    private void SetPlayerHealth()
    {
        playerHealth.text = "Health: " + health;
    }

    public void NotifyMe(EventActions actions)
    {
        if(actions == EventActions.damaged)
        {
            health -= 1;
        }
    }
}
