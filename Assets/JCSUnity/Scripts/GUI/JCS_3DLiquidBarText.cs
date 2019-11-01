﻿/**
 * $File: JCS_3DLiquidBarText.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                    Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace JCSUnity
{
    /// <summary>
    /// Object GUI which will do like the counter show.
    /// </summary>
    [RequireComponent(typeof(JCS_3DLiquidBar))]
    public class JCS_3DLiquidBarText
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        // Counter with the liquid bar?
        private JCS_3DLiquidBar mLiquidBar = null;


        [Header("** Runtime Variables (JCS_3DLiquidBarText) **")]

        [Tooltip("Text to do the effect.")]
        [SerializeField]
        private Text mCounterText = null;

        [Tooltip("This give the transformation for the Word space to Canvas space.")]
        [SerializeField]
        private Transform mCounterTextWorldTransform = null;

        [Tooltip("Text Render maxinum of the liquid bar value.")]
        [SerializeField]
        private Text mFullText = null;

        [Tooltip("This give the transformation for the Word space to Canvas space.")]
        [SerializeField]
        private Transform mFullTextWorldTransform = null;


        [Tooltip("Sprite Render the current value of the liquid bar.")]
        [SerializeField]
        private JCS_DeltaNumber mCounterTextSprite = null;

        [Tooltip("Sprite Render the max value of the liquid bar.")]
        [SerializeField]
        private JCS_DeltaNumber mFullTextSprite = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public JCS_DeltaNumber CounterTextSprite { get { return this.mCounterTextSprite; } set { this.mCounterTextSprite = value; } }
        public JCS_DeltaNumber FullTextSprite { get { return this.mFullTextSprite; } set { this.mFullTextSprite = value; } }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            this.mLiquidBar = this.GetComponent<JCS_3DLiquidBar>();
        }

        private void LateUpdate()
        {
            FitCanvas();

            DoTextRender();
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

        /// <summary>
        /// Find the value and set the text to value.
        /// </summary>
        private void DoTextRender()
        {
            if (mCounterText != null)
                mCounterText.text = ((int)mLiquidBar.GetCurrentValue()).ToString();

            if (mFullText != null)
                mFullText.text = mLiquidBar.MaxValue.ToString();

            if (mCounterTextSprite != null)
                mCounterTextSprite.UpdateScore((int)mLiquidBar.GetCurrentValue());

            if (mFullTextSprite != null)
                mFullTextSprite.UpdateScore((int)mLiquidBar.MaxValue);
        }

        /// <summary>
        /// Make the Canvas space text fit in world space.
        /// </summary>
        private void FitCanvas()
        {
            if (mCounterText != null &&
                mCounterTextWorldTransform != null
                )
            {
                mCounterText.rectTransform.anchoredPosition = JCS_Camera.main.WorldToCanvasSpace(this.mCounterTextWorldTransform.position);
            }

            if (mFullText != null &&
                mFullTextWorldTransform != null)
            {
                mFullText.rectTransform.anchoredPosition = JCS_Camera.main.WorldToCanvasSpace(this.mFullTextWorldTransform.position);
            }

        }

    }
}
