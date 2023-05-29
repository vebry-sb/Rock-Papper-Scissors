using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
   [SerializeField] Character selectedCharacter;
   [SerializeField] List<Character> characterList;
   [SerializeField] Transform atkRef;

   public Character SelectedCharacter { get => selectedCharacter; }

   public void Prepare()
   {
      selectedCharacter = null;
   }

   public void SelectCharacter(Character character)
   {
      selectedCharacter = character;
   }

   public void SetPlay(bool value)
   {
      foreach (var character in characterList)
      {
         character.Button.interactable = value;
      }
   }

   public void Attack()
   {
      selectedCharacter.transform.DOMove(endValue: atkRef.position, 1f, true).SetEase(ease: Ease.InOutBounce);
   }

   public bool IsAttacking()
   {
      return true;
   }
}
