using System;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class SkillIcon : MonoBehaviour
{
    public Button IconImage;
    public int SkillNumber;

    public SkillIcon(Button _image, int _skillNumber)
    {
        IconImage = _image;
        SkillNumber = _skillNumber;
    }
    
}
