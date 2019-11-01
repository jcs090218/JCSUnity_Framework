/**
 * $File: JCS_2DDestroyAnimEndEvent.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Destroy the gameobject after done playing the 2D animation.
    /// </summary>
    [RequireComponent(typeof(JCS_2DAnimation))]
    public class JCS_2DDestroyAnimEndEvent 
        : MonoBehaviour
    {
        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        private JCS_2DAnimation m2DAnimation = null;

        [Header("** Runtime Variables (JCS_2DDestroyAnimEndEvent) **")]

        [Tooltip("How many times the animation plays before destorying.")]
        [SerializeField]
        private int mLoopTimes = 1;

        // Loop count.
        private int mLoopCount = 0;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public int LoopTimes { get { return this.mLoopTimes; } set { this.mLoopTimes = value; } }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            this.m2DAnimation = this.GetComponent<JCS_2DAnimation>();
        }

        private void LateUpdate()
        {
            if (!this.m2DAnimation.IsDonePlaying)
                return;

            ++mLoopCount;

            if (mLoopCount <= mLoopTimes)
                Destroy(this.gameObject);
            else
            {
                // play once more.
                m2DAnimation.Play();
            }
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
