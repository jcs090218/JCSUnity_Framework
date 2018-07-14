﻿/**
 * $File: JCS_ImageLoader.cs $
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
    /// Image loader, load image to sprite from resource.
    /// </summary>
    public class JCS_ImageLoader
    {

        public JCS_ImageLoader()
        {

        }

        /// <summary>
        /// Load Image by file path.
        /// </summary>
        /// <param name="filePath"> Image file path. </param>
        /// <param name="pixelPerUnit"> Pixel per unit conversion to world space. </param>
        /// <returns> Sprite object. </returns>
        public static Sprite LoadImage(string filePath, float pixelPerUnit = 40)
        {
            Sprite img = null;

            var tex = new Texture2D(2, 2);
            var pngBytes = System.IO.File.ReadAllBytes(filePath);
            tex.LoadImage(pngBytes);

            Rect rect = new Rect();
            rect.x = 0;
            rect.y = 0;
            rect.height = tex.height;
            rect.width = tex.width;

            img = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f), pixelPerUnit);

            return img;
        }
    }
}
