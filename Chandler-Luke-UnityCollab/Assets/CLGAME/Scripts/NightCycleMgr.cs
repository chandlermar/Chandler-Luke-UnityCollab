using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NightCycleMgr : MonoBehaviour
{
    public Light DirectionalLight;
    [SerializeField] private NightCyclePresets Preset;

    [SerializeField, Range(0, 24)] private float TimeOfDay;

    public bool _cycleEnabled = false;

   

    private void Update()
    {

        if (Preset == null)
            return;

        
            if (Application.isPlaying)
            {
                TimeOfDay += Time.deltaTime * .2f;
                TimeOfDay %= 24; //Clamp between  0-24
                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                UpdateLighting(TimeOfDay / 24f);
            }
        
        
    }

    private void UpdateLighting(float timePercent)
    {
        if (!_cycleEnabled)
        {
            return;
        }
        else
        {
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
            RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
            }
        }
           
    }

    private void OnValidate()
    {
        
        if (DirectionalLight != null)
            return;
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }

            }

        }
       
    }
}
