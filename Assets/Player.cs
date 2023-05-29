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
      selectedCharacter.transform
         .DOMove(endValue: atkRef.position, 1f, true)
         .SetEase(ease: Ease.InOutBounce); //Bisa dihapus
   }

   public bool IsAttacking()
   {
         return DOTween.IsTweening(targetOrId:selectedCharacter.transform);
   }

   public void TakeDamage(int damageValue)
   {
      selectedCharacter.ChangeHP(amount: -damageValue);
      var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
      spriteRend.DOColor(endValue : Color.red, 0.1f).SetLoops(6, loopType: LoopType.Yoyo);
   }

   public bool IsDamaging()
   {
      var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
      return DOTween.IsTweening(targetOrId: spriteRend);
   }

   public void Remove(Character character)
   {
      if(characterList.Contains(item: character) == false) 
         return;    

      character.Button.interactable = false;
      character.gameObject.SetActive(false);
      characterList.Remove(item: character);
   }
}
