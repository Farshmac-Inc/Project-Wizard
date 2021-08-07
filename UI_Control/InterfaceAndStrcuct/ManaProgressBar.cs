using UnityEngine.UI;

[System.Serializable]
public struct ManaProgressBar
{
    public Slider progresseBar;
    public ManaType manaType;

    public ManaProgressBar(Slider _progressBar, ManaType _manaType)
    {
        progresseBar = _progressBar;
        this.manaType = _manaType;
    }
}
