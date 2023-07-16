using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class getCharacterData : ScriptableObject
{
    public CharacterData[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public CharacterData GetCharacter(int index)
    {
        return character[index];
    }
}
