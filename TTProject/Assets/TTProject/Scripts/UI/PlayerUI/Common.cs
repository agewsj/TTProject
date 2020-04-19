using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    #region Animation
    public enum AnimationState
    {
        Idle,
        Attack,
        Hit        
    }

    public Animator animator;

    public void initTrigger()
    {
        animator.ResetTrigger("idle");
        animator.ResetTrigger("attack");
        animator.ResetTrigger("hit");
    }

    public void SetAnimatorState(AnimationState _state)
    {
        if (animator == null)
            return;

        initTrigger();

        switch (_state)
        {
            case AnimationState.Idle:
                animator.SetTrigger("idle");
                break;
            case AnimationState.Attack:
                animator.SetTrigger("attack");
                break;
            case AnimationState.Hit:
                animator.SetTrigger("hit");
                break;
        }
    }
    #endregion

    #region Effect
    public GameObject normalAttackEffect;
    GameObject attackEffect = null;

    
    Animator attackAnimator = null;
    float attackAnimationTime = 0.0f;
    Coroutine attackCoroutine = null;

    public Vector2 attackEffectPos = Vector2.zero;


    public void SetActiveNormalAttackEffect()
    {
        if (attackEffect == null)
        {
            attackEffect = Instantiate(normalAttackEffect.gameObject, transform) as GameObject;
            attackEffect.GetComponent<RectTransform>().anchoredPosition = attackEffectPos;
            attackAnimator = attackEffect.GetComponent<Animator>();
            attackAnimationTime = attackAnimator.GetCurrentAnimatorStateInfo(0).length;

            attackCoroutine = StartCoroutine(EndActiveNormalAttackEffect(attackAnimationTime));
        }
        else
        {
            attackEffect.gameObject.SetActive(true);

            if (attackAnimator == null)
            {
                Debug.Log("Attack Animation Info is Null");
                attackAnimator = attackEffect.GetComponent<Animator>();
                attackAnimationTime = attackAnimator.GetCurrentAnimatorStateInfo(0).length;
            }

            if (attackCoroutine != null)
            {
                Debug.Log("Stop Attack Coroutine");
                StopCoroutine(attackCoroutine);
            }

            attackCoroutine = StartCoroutine(EndActiveNormalAttackEffect(attackAnimationTime));
        }
    }

    public IEnumerator EndActiveNormalAttackEffect(float _waitTime)
    {
        Debug.Log("StartCoroutine AttackEffect Wailt Time : " + _waitTime);

        yield return new WaitForSeconds(_waitTime);        

        attackEffect.gameObject.SetActive(false);
    }
    #endregion
}
