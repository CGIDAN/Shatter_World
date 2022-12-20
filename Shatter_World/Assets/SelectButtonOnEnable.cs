using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnEnable : MonoBehaviour
{
    public Button optionsButton;

    void OnEnable()
    {
        optionsButton.Select();
    }
}
