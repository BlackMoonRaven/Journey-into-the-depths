using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPlayerCharacteristicsUI : MonoBehaviour
{
    const string CurrentPlayerPrefs = "CurrentPlayer";

    [Header("TextStats")]
    [SerializeField] private TMP_Text[] _textCharacteristics = new TMP_Text[12];

    [Header("ScriptableObject")]
    [SerializeField] private PlayerCharackters _playerCharackters;

    private Character _player;
    private GameObject _characterUI;

    public void UpdateCharacteristic()
    {
        _player = _playerCharackters.characters[PlayerPrefs.GetInt(CurrentPlayerPrefs)];
        _textCharacteristics[0].text = _player.health.ToString();
        _textCharacteristics[1].text = _player.armor.ToString();
        _textCharacteristics[2].text = _player.damage.ToString();
        _textCharacteristics[3].text = _player.stamina.ToString();
        _textCharacteristics[4].text = _player.strength.ToString();
        _textCharacteristics[5].text = _player.agility.ToString();
        _textCharacteristics[6].text = _player.intellect.ToString();
        _textCharacteristics[7].text = _player.range.ToString();
        _textCharacteristics[8].text = _player.moveSpeed.ToString();
        _textCharacteristics[9].text = _player.attackSpeed.ToString();
        _textCharacteristics[10].text = _player.vampiric.ToString();
        _textCharacteristics[11].text = _player.luck.ToString();
    }

    public void DisplaySprite()
    {
        if (_characterUI != null)
        {
            Destroy(_characterUI);
        }
        _characterUI = Instantiate(_player.sprite, GameObject.FindGameObjectWithTag("CharacterUI").transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("CharacterUI").transform);
    }

}
