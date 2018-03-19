using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShowAnimator : MonoBehaviour {

    //playback types - run once or loop forever
    public enum ANIMATOR_PLAYBACK_TYPE
    {
        PLAYONCE = 0,
        PLAYLOOP = 1
    };
    //Playback type for this animation
    public ANIMATOR_PLAYBACK_TYPE PlaybackType = ANIMATOR_PLAYBACK_TYPE.PLAYONCE;
    //Frames per seconds to play for this animation
    public int FPS = 5;
    //CUSTOM ID FOR ANIMATION - used with function PlaySpriteAnimation
    public int AnimationID = 0;
    //Frames of animation
    public SpriteRenderer[] Sprites = null;
    //Should auto-play?
    public bool AutoPlay = false;
    //should first hide all sprite renderers on playback? pr leave at defaults
    public bool HideSpritesOnStart = true;
    //boolean whether animation is currently playing
    bool IsPlaying = false;

    private void Start()
    {
        //Should we auto-play at Start up?
        if(AutoPlay){
            StartCoroutine(PlaySpriteAnimation(AnimationID));
        }
    }

    //function to run animation
    public IEnumerator PlaySpriteAnimation(int AnimID = 0){
        //check if this animation should be started. Coud be called via SendMessage or BroadCastMessage
        if (AnimID != AnimationID) yield break;

        //should hide all Sprite renderers
        if(HideSpritesOnStart){
            foreach(SpriteRenderer SR in Sprites){
                SR.enabled = false;
            }
        }
        //Set is playing
        IsPlaying = true;
        //Calculate delay time
        float DelayTime = 1.0f/FPS;
        //RUN ANIMATION AT LEAST ONCE
        do
        {
            foreach (SpriteRenderer SR in Sprites)
            {
                SR.enabled = !SR.enabled;
                yield return new WaitForSeconds(DelayTime);
                SR.enabled = !SR.enabled;
            }

        } while (PlaybackType == ANIMATOR_PLAYBACK_TYPE.PLAYLOOP);

        //Stop Animation
        StopSpriteAnimation(AnimationID);
    }
    //function stop animation
    public void StopSpriteAnimation(int AnimID = 0){
        //check if this animation can and should be stopped
        if ((AnimID != AnimationID) || (!IsPlaying)) return;

        //Stop all coroutines(animation will no longer play)
        StopAllCoroutines();

        //Is playing false
        IsPlaying = false;
        //Send Sprite Animation stopped event to gameobject
        gameObject.SendMessage("SpriteAnimationStopped",
                               AnimID,
                               SendMessageOptions
                               .DontRequireReceiver);
    }
}
