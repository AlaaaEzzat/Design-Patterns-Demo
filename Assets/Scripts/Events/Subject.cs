using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    public List<Iobservers> observers = new List<Iobservers>();

    public void AddObserver(Iobservers observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Iobservers observer)
    {
        observers.Remove(observer);
    }

    protected void NotifyObservers(EventActions actions)
    {
        foreach (Iobservers observer in observers)
        {
            observer.NotifyMe(actions);
        }
    }
}
