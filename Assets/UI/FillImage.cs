using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Fill Image: Implements IIntListener to update the fill amount of an image
[RequireComponent(typeof(Image))]
public class FillImage : MonoBehaviour, IIntListener
{
    Image image;
    void Awake() => image = GetComponent<Image>();
    public void IntUpdate(IntWrapper intWrapper)
    {
        image.fillAmount = intWrapper.Ratio;
    }
}
