using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LightData", menuName = "Light/Data")]
public class LightData : ScriptableObject
{
    public List<LightProperties> lightPropertiesList;
    
    public LightProperties GetLightProperties(Season season, LightType lightType)
    {
        return lightPropertiesList.Find(l => l.season == season && l.lightType == lightType);
    }
}

[System.Serializable]
public class LightProperties
{
    public Season season;
    public LightType lightType;
    public Color lightColor;
    public float lightIntensity;
}