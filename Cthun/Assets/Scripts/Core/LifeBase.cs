using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBase : MonoBehaviour
{
    public int totalLife;
    protected int currentLife;

    // Use this for initialization
    protected void Start()
    {
        currentLife = totalLife;
    }

    // Update is called once per frame
    protected void Update()
    {
       
    }

    public void ApplyDamage(int damage)
    {
        currentLife -= damage;
        OnDamage();
        if (currentLife <= 0)
            OnDie();
    }

    public abstract void OnDamage();
    public abstract void OnDie();

    public int GetCurrentLife()
    {
        return currentLife;
    }
}