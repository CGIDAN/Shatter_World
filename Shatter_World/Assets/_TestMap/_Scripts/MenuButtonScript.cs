using UnityEngine;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public Button button;
    public GameObject canvas;
    private bool isShowing;

    void Start()
    {
        button.onClick.AddListener(ToggleCanvas);
        isShowing = false;
    }

    void ToggleCanvas()
    {
        isShowing = !isShowing;
        canvas.SetActive(isShowing);
    }
}
