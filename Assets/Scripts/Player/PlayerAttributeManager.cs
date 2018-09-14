using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttributeManager : MonoBehaviour {
    public int minStamina;
    public int maxStamina;
    public float runStaminaBurnRate;
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent staminaChanged = new FloatEvent();
    private float stamina;
    public float Stamina
    {
        get
        {
            return stamina;
        }

        set
        {
            stamina = value;
            staminaChanged.Invoke(value);
        }
    }

    public float RunStaminaBurnRate
    {
        get
        {
            return runStaminaBurnRate;
        }

        set
        {
            runStaminaBurnRate = value;
        }
    }

    void Start () {
        stamina = maxStamina;
	}
}
