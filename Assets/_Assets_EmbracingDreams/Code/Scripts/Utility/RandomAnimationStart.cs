using System.Threading.Tasks;
using UnityEngine;

public class RandomAnimationStart : MonoBehaviour
{
    public Animator animator;
    public int randomRangeMin = 50;
    public int randomRange = 450;

    private async void Start()
    {
        StartRandomAnimation();
    }

    async void StartRandomAnimation()
    {
        await Task.Delay(8000); // Wait for 30 milliseconds
        if (animator == null) animator = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        animator.enabled = false;

        // Delay the animation start by 10 milliseconds
        await Task.Delay(Random.Range(randomRangeMin, randomRange)); // Wait for 30 milliseconds
        
        if (animator == null) return;
        animator.enabled = true;
        animator.Play(stateInfo.fullPathHash, 0);
    }

    void DisableAnimate()
    {
        if (animator == null) animator = GetComponent<Animator>();
        animator.enabled = false;
        Invoke(nameof(Animate), 0.01f);
    }

    void Animate()
    {
        if (animator == null) animator = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(stateInfo.fullPathHash, 0, Random.Range(randomRangeMin, randomRange));
        animator.enabled = true;
    }
}