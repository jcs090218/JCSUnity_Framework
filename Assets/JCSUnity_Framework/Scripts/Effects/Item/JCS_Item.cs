﻿/**
 * $File: JCS_ItemPickable.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information $
 *		                Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;

namespace JCSUnity
{

    [RequireComponent(typeof(BoxCollider))]
    public class JCS_Item
        : JCS_UnityObject
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        private bool mCanPick = true;
        private BoxCollider mBoxCollider = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public BoxCollider GetBoxCollider() { return this.mBoxCollider; }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            mBoxCollider = this.GetComponent<BoxCollider>();

            // update the data once 
            // depends on what game object is.
            UpdateUnityData();
        }

        private void Update()
        {

        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions
        public void Drop()
        {

        }
        public void Pick()
        {

        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions
        

    }
}
