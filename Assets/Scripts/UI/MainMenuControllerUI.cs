using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuControllerUI : MonoBehaviour
{
    const string CurrentPlayerPrefs = "CurrentPlayer";

    [Header("UI")]
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _characterUI;

    public UnityEvent ShowStatsAndCharacter;

    private void Awake()
    {
        ShowStatsAndCharacter.AddListener(GameObject.FindGameObjectWithTag("Stats").GetComponent<DisplayPlayerCharacteristicsUI>().UpdateCharacteristic);
        ShowStatsAndCharacter.AddListener(GameObject.FindGameObjectWithTag("Stats").GetComponent<DisplayPlayerCharacteristicsUI>().DisplaySprite);
    }

    private void Start()
    {
        _shop.SetActive(false);
    }

    // Метод запускає гру
    public void Play()
    {
        ShowStatsAndCharacter.RemoveAllListeners();
        SceneManager.LoadScene(1);
    }

    // Метод для виходу із гри
    public void Exit() => Application.Quit();


    // Відкриття магазину персонажів
    public void OpenShopMenu()
    {
        _shop.SetActive(true);
        _characterUI.SetActive(true);
    }
    // Закрити магазин персонажів
    public void Back()
    {
        _shop.SetActive(false);
        _characterUI.SetActive(false);
    }
    // Вибір персонажа
    public void SelectCharacter(int id)
    {
        PlayerPrefs.SetInt(CurrentPlayerPrefs, id);
        ShowStatsAndCharacter?.Invoke();
    }


}
