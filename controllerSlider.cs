using UnityEngine.UI;
using UnityEngine;

public class controllerSlider : MonoBehaviour
{
    public Slider slider;
    public float speed;
    public GameObject GameWin;
    void Update()
    {
        slider.value += speed * Time.deltaTime;
        if(slider.value == slider.maxValue)
        {
            GameWin.SetActive(true);
        }
    }
}
