﻿/**
 * $File: JCS_DestroySoundEndEvent.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;

namespace JCSUnity
{
    /// <summary>
    /// Destroy the gameobject after the sound is done playing.
    /// </summary>
    [RequireComponent(typeof(JCS_SoundPlayer))]
    public class JCS_DestroySoundEndEvent
        : MonoBehaviour
    {
        /* Variables */

        private JCS_SoundPlayer mSoundPlayer = null;


        /* Setter & Getter */

        public void SetAudioClipAndPlayOneShot(AudioClip clip, JCS_SoundSettingType type)
        {
            if (mSoundPlayer == null)
                mSoundPlayer = this.GetComponent<JCS_SoundPlayer>();

            this.mSoundPlayer.GetAudioSource().clip = clip;
            this.mSoundPlayer.PlayOneShot(clip, type);
        }


        /* Functions */

        private void Update()
        {
            if (mSoundPlayer.GetAudioSource().isPlaying)
                return;

            Destroy(this.gameObject);
        }
    }
}
