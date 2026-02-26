using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class EnvironmentLightingControls : MonoBehaviour
{
    public Toggle useSkyboxToggle;
    public Toggle enableFog;
    public Slider skyboxIntensitySlider;
    //public Text skyboxIntensityText;
    public TextMeshProUGUI skyboxIntensityText;

    public bool UseSkybox
    {
        get => (RenderSettings.ambientMode == AmbientMode.Skybox);
        set
        {

            RenderSettings.ambientMode = (value) ?
                AmbientMode.Skybox : AmbientMode.Flat;
            skyboxIntensitySlider.interactable = value;
            skyboxIntensityText.gameObject.SetActive(value);
        }
    }

    public bool EnableFog
    {
        get => RenderSettings.fog;
        set => RenderSettings.fog = value;
    }

    public float SkyboxIntensity
    {
        get => RenderSettings.ambientIntensity;
        set
        {
            RenderSettings.ambientIntensity = value;
            skyboxIntensityText.text = value.ToString("F1");
        }
    }
    
    private void Start()
    {
        useSkyboxToggle.isOn = UseSkybox;
        skyboxIntensitySlider.value = SkyboxIntensity;
        enableFog.isOn = EnableFog;

        // add event listener on the toggle
        useSkyboxToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool value)
    {
        if(value)
        {
            RenderSettings.ambientMode = AmbientMode.Skybox; 
            Debug.Log(value);

        }
        else
        {
            RenderSettings.ambientMode = AmbientMode.Flat;
            Debug.Log(value);
        }   
    }

    void Update()
    {

    }
}
