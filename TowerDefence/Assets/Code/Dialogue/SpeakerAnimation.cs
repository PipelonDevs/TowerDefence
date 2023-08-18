using UnityEngine;

namespace Code.Dialogue
{
    // BACKLOG: "Animator"
    public class SpeakerAnimation : MonoBehaviour
    {
        public Animator anim;

        public bool isTalking;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            isTalking = false;
        }

        public void PlayAnimation(string _name)
        {
            switch (_name)
            {
                case "idle":
                    anim.SetTrigger("toIdle");
                    break;
                case "talk":
                    isTalking = true;
                    anim.SetTrigger("toTalk");
                    break;
                case "think":
                    anim.SetTrigger("toThink");
                    break;
            }
        }
    }
}