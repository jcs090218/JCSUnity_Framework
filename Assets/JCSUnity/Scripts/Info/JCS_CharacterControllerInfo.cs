﻿/**
 * $File: JCS_CharacterControllerInfo.cs $
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
    /// Provide all the info that scripter needed for 
    /// scripting the character's movement, collision 
    /// detection, etc.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class JCS_CharacterControllerInfo
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        private CharacterController mCharacterController = null;
        [Header("** Check Variables **")]
        [SerializeField] private float mWidth = 0;
        [SerializeField] private float mHeight = 0;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public CharacterController GetCharacterController() { return this.mCharacterController; }
        public bool isGrounded { get { return this.mCharacterController.isGrounded; } }
        public float Width { get { return this.mWidth; } }
        public float Height { get { return this.mHeight; } }
        public float HalfWidth { get { return this.Width / 2.0f; } }
        public float HalfHeight { get { return this.Height / 2.0f; } }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            mCharacterController = this.GetComponent<CharacterController>();


            Vector2 widthHeight = JCS_Physics.GetColliderWidthHeight(mCharacterController);

            mWidth = widthHeight.x;
            mHeight = widthHeight.y;
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
