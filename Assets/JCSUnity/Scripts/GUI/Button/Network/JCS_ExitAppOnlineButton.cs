/**
 * $File: JCS_ExitAppOnlineButton.cs $
 * $Date: 2017-09-03 14:40:41 $
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
    /// Exit button with change scene effect.
    /// Multiplayer Version.
    /// </summary>
    public class JCS_ExitAppOnlineButton 
        : JCS_Button
    {
        public override void JCS_OnClickCallback()
        {
            // load exit button scene.
            JCS_SceneManager.instance.LoadScene("JCS_ApplicationCloseSimulateSceneOnline");
        }
    }
}
