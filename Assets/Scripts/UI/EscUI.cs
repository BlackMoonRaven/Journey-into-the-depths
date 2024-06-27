using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EscUI : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private GameObject _escMenu;

    private bool _isEsc = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _escMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void Continue()
    {
        _playerUI.SetActive(_isEsc);
        _escMenu.SetActive(!_isEsc);
        _isEsc = !_isEsc;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
