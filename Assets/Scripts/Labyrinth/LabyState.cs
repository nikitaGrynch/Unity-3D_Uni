using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LabyState : MonoBehaviour
{
    public static float ballForceFactor { get; set; }
    //private static List<Action<String>> observers = new();
    private static Dictionary<String, List<Action<String>>> observers = null!;
    private static void InitObservers()
    {
        observers = new();
        foreach (var prop in typeof(LabyState).GetProperties())
        {
            observers.Add(prop.Name, new List<Action<string>>());
        }
    }

    public static void AddObserver(Action<String> observer, params String[] propertyNames)
    {
        if(observers == null)
        {
            InitObservers();
        }
        foreach(var propertyName in propertyNames)
        {
            if (!observers.ContainsKey(propertyName))
            {
                throw new Exception($"'{propertyName}' is not a State property");
            }
            observers[propertyName].Add(observer);
        }
    }
    public static void RemoveObserver(Action<String> observer, params String[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            if (observers.ContainsKey(propertyName))
            {
                observers[propertyName].Remove(observer);
            }
        }
    }
    private static void NotifyObservers([CallerMemberName]String propertyName = "")
    {
        if (observers == null)
        {
            return;
        }
        if (observers.ContainsKey(propertyName))
        {
            observers[propertyName].ForEach(observer => observer.Invoke(propertyName));
        }
    }

    private static float _key1Remained;
    public static float key1Remained
    {
        get => _key1Remained;
        set
        {
            _key1Remained = value;
            NotifyObservers();
        }
    }

    private static float _key2Remained;
    public static float key2Remained
    {
        get => _key2Remained;
        set
        {
            _key2Remained = value;
            NotifyObservers();
        }
    }

    private static bool _key2Activated;
    public static bool key2Activated
    {
        get => _key2Activated;
        set
        {
            if(value != _key2Activated)
            {
                _key2Activated = value;
                NotifyObservers();
            }
        }
    }
    public static bool key1Collected { get; set; }
    private static bool _key2Collected;
    public static bool key2Collected
    {
        get => _key2Collected;
        set
        {
            if(value != _key2Collected)
            {
                _key2Collected = value;
                NotifyObservers();
            }
        }
    }
    public static bool firstPersonView { get; set; }
    public static bool isDay { get; set; }
    public static bool isPaused { get; set; }
    public static float spotLightIntensity { get; set; }
    public static float lightIntensity { get; set; }
}
