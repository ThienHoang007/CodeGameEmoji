using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Froce;
    [SerializeField] private Transform posGun;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> rawImages = new List<GameObject>();
    private int value;
    private bool isUp = true;
    private bool isDown = true;
    private bool isAttach = true;
    private bool isBan = false;

    public Slider slider;
    private void Start()
    {
        value = Random.Range(1, 5);
        UpdateUI(value);
    }
    void Update()
    {
        GunMove();
        checkAngle();
        Ban();
        updateUi();
    }
    private void GunMove()
    {
        if(Input.GetKey(KeyCode.W) && isUp)
        {
            Quaternion angel = this.transform.rotation;
            angel.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
            this.transform.rotation = angel;
        }
        else if(Input.GetKey(KeyCode.S) && isDown)
        {
            Quaternion angel = this.transform.rotation;
            angel.eulerAngles -= new Vector3(0, 0, speed * Time.deltaTime);
            this.transform.rotation = angel;
        }
    }
    private void checkAngle()
    {
        float angle = this.transform.rotation.z * (180 / Mathf.PI);
        if(angle <= -15f)
        {
            isDown = false;
            isUp = true;
        }
        else if(angle >= 25f) 
        {
            isDown = true;
            isUp = false;
        }
        else
        {
            isDown = true;
            isDown = true;
        }
    }
    private GameObject GetGameObject(int value)
    {
        switch (value)
        {
            case 1: return gameObjects[0];
            case 2: return gameObjects[1];
            case 3: return gameObjects[2];
            case 4: return gameObjects[3];
            default: return null;
        }
    }
    private void UpdateUI(int value)
    {
        for (int i = 0; i <= 3; i++) rawImages[i].SetActive(false);
        switch (value)
        {
            case 1:
                rawImages[0].SetActive(true);
                break;
            case 2:
                rawImages[1].SetActive(true);
                break;
            case 3:
                rawImages[2].SetActive(true);
                break;
            case 4:
                rawImages[3].SetActive(true);
                break;
        }
    }
    private void Ban()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isAttach)
        {
            isAttach = false;
            isBan = true;
            slider.value = slider.minValue;
            StartCoroutine(AttachAfterTime());
            Instantiate(GetGameObject(value), posGun.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(this.transform.right * Froce, ForceMode2D.Impulse);
            value = Random.Range(1, 5);
            UpdateUI(value);
        }
    }
    private void updateUi()
    {
        if(isBan)
        {
            slider.value += Time.deltaTime;
        }
    }
    private IEnumerator AttachAfterTime()
    {
        yield return new WaitForSeconds(2f);
        isAttach = true;
        isBan = false;
    }
}
