using UnityEngine;

public class MutantAnimator : MonoBehaviour {

    Animator animator;
    GoToClickPosition goToClickPos;

    private void Awake() {
        
        animator = GetComponent<Animator>();
        goToClickPos = GetComponent<GoToClickPosition>();

    }

    void Start() {
        
    }

    void Update() {
        
        if(goToClickPos.GetSpeed > 0) {
            animator.SetBool("running", true);
        } else {
            animator.SetBool("running", false);
        }

    }

}




        