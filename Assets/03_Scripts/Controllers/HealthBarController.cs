using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Scrollbar healthBar;

    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] private float updateSpeed = 0.1f;

    private GameManage _gameManage;

    private float currentValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManage = GameManage.instance;
        if (_gameManage == null)
        {
            Debug.Log("WE DON'T FOUND GAMEMANAGER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetValue = (float)_gameManage.health / 100f;
        StartCoroutine(AnimatedHealthBar(targetValue));
        if (healthText != null)
        {
            healthText.text = _gameManage.health.ToString();
        }
    }

    IEnumerator AnimatedHealthBar(float targetValue)
    {
        while (Mathf.Abs(healthBar.size - targetValue) > 0.01f)
        {
            healthBar.size = Mathf.Lerp(healthBar.size, targetValue, Time.deltaTime * updateSpeed);
            yield return null;
        }

        healthBar.size = targetValue;
        UpdateHandleColor();
    }

    private void UpdateHandleColor()
    {
        Image handleImage = healthBar.handleRect.GetComponent<Image>();
        float healthPercent = (float)_gameManage.health / 100f;
        if (healthPercent > 0.5f)
        {
            handleImage.color = Color.green;
        }
        else if (healthPercent > 0.25f)
        {
            handleImage.color = Color.yellow;
        }
        else
        {
            handleImage.color = Color.red;
        }
    }
    
}
