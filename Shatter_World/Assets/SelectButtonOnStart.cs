using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnStart : MonoBehaviour
{
    public Button buttonToSelect;

    void Start()
    {
        buttonToSelect.Select();
    }
}