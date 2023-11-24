using UnityEngine;

public class MirrorActivate : MonoBehaviour
{
    [SerializeField]
    private Material _mirrorFrame;
    private Color _startColor;

    private void Start()
    {
        if ( _mirrorFrame == null )
        {
            Debug.LogError("Material missing from MirrorActivate Script.");
        }
        else
        {
            _startColor = _mirrorFrame.color;
        }
    }

    public void ChangeColor(bool isChanged)
    {
        if (!isChanged)
        {
            _mirrorFrame.color = _startColor;
        }
        else
        {
            _mirrorFrame.color = Color.green;
        }
    }
}
