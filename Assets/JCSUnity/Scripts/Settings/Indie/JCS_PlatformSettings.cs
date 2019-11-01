
using System;
/**
* $File: JCS_PlatformSettings.cs $
* $Date: 2017-05-02 23:52:09 $
* $Revision: $
* $Creator: Jen-Chieh Shen $
* $Notice: See LICENSE.txt for modification and distribution information 
*	                 Copyright (c) 2017 by Shen, Jen-Chieh $
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JCSUnity
{

    /// <summary>
    /// Setting of all the platform type.
    /// </summary>
    public class JCS_PlatformSettings
        : JCS_Settings<JCS_PlatformSettings>
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        [Header("** Runtime Variables (JCS_PlatformSettings) **")]

        [Tooltip("How much push down ward if down jump triggered.")]
        [Range(0, 1)]
        public float POSITION_PLATFORM_DOWN_JUMP_FORCE = 0.01f;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            instance = CheckSingleton(instance, this);
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        //----------------------
        // Protected Functions

        /// <summary>
        /// Instead of Unity Engine's scripting layer's DontDestroyOnLoad.
        /// I would like to use own define to transfer the old instance
        /// to the newer instance.
        /// 
        /// Every time when unity load the scene. The script have been
        /// reset, in order not to lose the original setting.
        /// transfer the data from old instance to new instance.
        /// </summary>
        /// <param name="_old"> old instance </param>
        /// <param name="_new"> new instance </param>
        protected override void TransferData(JCS_PlatformSettings _old, JCS_PlatformSettings _new)
        {
            _new.POSITION_PLATFORM_DOWN_JUMP_FORCE = _old.POSITION_PLATFORM_DOWN_JUMP_FORCE;
        }

        //----------------------
        // Private Functions

    }
}
