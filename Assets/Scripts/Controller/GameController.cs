using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    const string CurrentPlayerPrefs = "CurrentPlayer";

    [Header("Scripts")]
    [SerializeField] private PlayerCharackters _playerCh;

    [Header("UI")]
    [SerializeField] private Image _healthUI;

    private float _currentHealth;
    private Character _currentCharacter;

    public UnityEvent PlayerEnterTheGame;

    private void Awake()
    {
        // Пошук ID поточного персонажа, якщо ж не знайдено, то використовується ID 0;
        if (!PlayerPrefs.HasKey(CurrentPlayerPrefs))
        {
            PlayerPrefs.SetInt(CurrentPlayerPrefs, 0);
        }

        _currentCharacter = _playerCh.characters[PlayerPrefs.GetInt(CurrentPlayerPrefs)];
        _currentHealth = _currentCharacter.health;
        Instantiate(_currentCharacter.sprite, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Player").transform);

        PlayerEnterTheGame.AddListener(GameObject.FindGameObjectWithTag("Stats").GetComponent<DisplayPlayerCharacteristicsUI>().UpdateCharacteristic);
    }

    private void Start()
    {
        PlayerEnterTheGame?.Invoke();
    }

    // Отримання шкоди
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _healthUI.fillAmount = ConvertToPercent(_currentCharacter.health, _currentHealth);
    }

    // Конвертація здоров'я гравця в проценти
    private float ConvertToPercent(float maxValue, float value) => value / maxValue;

}
