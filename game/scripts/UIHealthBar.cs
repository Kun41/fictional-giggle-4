using System.Collections; // Bæta við í örlögum til að nota fylki
using System.Collections.Generic; // Bæta við í örlögum til að nota generics
using UnityEngine; // Bæta við til að nota Unity API
using UnityEngine.UI; // Bæta við til að nota UI hluti í Unity

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; } // Opna aðgang að UIHealthBar með instance

    public Image mask; // Skilgreina mask sem mynd sem við notum til að skera úr
    float originalSize; // Upprunalegt stærð maskarinnar

    void Awake()
    {
        instance = this; // Setja instance sem þetta UIHealthBar hlut
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width; // Setja upprunalega stærð maskarinnar þegar leikurinn byrjar
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value); // Stilli stærð maskarinnar samkvæmt gildi sem er gefið
    }
}
