using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIStaminaBarHandler : MonoBehaviour {
    public Slider slider;
    private UnityAction<float> staminaChangedAction;

	void Start () {
        slider.minValue = SceneManager.PlayerAttributeManager.minStamina;
        slider.maxValue = SceneManager.PlayerAttributeManager.maxStamina;
        slider.value = SceneManager.PlayerAttributeManager.Stamina;

        staminaChangedAction += onStaminaChanged;
        SceneManager.PlayerAttributeManager.staminaChanged.AddListener(staminaChangedAction);
    }
	
	void onStaminaChanged(float newStamina)
    {
        slider.value = newStamina;
    }
}
