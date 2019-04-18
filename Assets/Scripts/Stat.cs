﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat{

    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    private float t;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            bar.MaxValue = value;
            this.maxVal = value;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }

    public void Add(float value)
    {
        CurrentVal += value;
    }

    public void Reduce(float value)
    {
        CurrentVal -= value;
    }

    public void Regen(float regenTimer, float regenAmount)
    {

        if (t <= Time.time)
        {
            CurrentVal += regenAmount;
            t = Time.time + regenTimer;
        }
    }

    public void Drain(float drainTimer, float drainAmount)
    {

        if (t <= Time.time)
        {
            CurrentVal -= drainAmount;
            t = Time.time + drainTimer;
        }
    }
}
