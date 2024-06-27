using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Melee,
    Ranger,
    Magic
}

[CreateAssetMenu(fileName = "NewPalyerCharackters", menuName = "PlayerCharackters")]
public class PlayerCharackters : ScriptableObject
{
    public List<Character> characters;
}

[Serializable]
public struct Character
{
    public string playerName;
    public AttackType attackType;
    public float health;
    public float armor;
    public float damage;
    public float stamina;
    public float strength;
    public float agility;
    public float intellect;
    public float range;
    public float moveSpeed;
    public float attackSpeed;
    public float vampiric;
    public int luck;
    public int ordinalNumber;
    public GameObject sprite;
}
