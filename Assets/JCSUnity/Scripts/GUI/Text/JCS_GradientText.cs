/**
 * $File: JCS_GradientText.cs $
 * $Date: 2018-08-11 12:36:27 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright © 2018 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JCSUnity
{
    /// <summary>
    /// Gradient text effect.
    /// </summary>
    public class JCS_GradientText
        : BaseMeshEffect
    {

        [Tooltip("Type of the gradient action.")]
        [SerializeField]
        private JCS_GradientType mGradientType = JCS_GradientType.TOP_DOWN;

        [Tooltip("First color. Either top or right.")]
        [SerializeField]
        private Color32 mFirstColor = Color.white;

        [Tooltip("Second color. Either down or left.")]
        [SerializeField]
        private Color32 mSecondColor = Color.black;


        public JCS_GradientType GradientType { get { return this.mGradientType; } set { this.mGradientType = value; } }
        public Color32 FirstColor { get { return this.mFirstColor; } set { this.mFirstColor = value; } }
        public Color32 SecondColor { get { return this.mSecondColor; } set { this.mSecondColor = value; } }


        public override void ModifyMesh(VertexHelper vh)
        {
            if (!this.IsActive())
                return;

            List<UIVertex> vertexList = new List<UIVertex>();
            vh.GetUIVertexStream(vertexList);

            ModifyVertices(vertexList);

            vh.Clear();
            vh.AddUIVertexTriangleStream(vertexList);
        }

        public void ModifyVertices(List<UIVertex> vertexList)
        {
            if (!IsActive())
            {
                return;
            }

            int count = vertexList.Count;
            if (count > 0)
            {
                if (mGradientType == JCS_GradientType.TOP_DOWN)
                {
                    float bottomY = vertexList[0].position.y;
                    float topY = vertexList[0].position.y;

                    for (int i = 1; i < count; i++)
                    {
                        float y = vertexList[i].position.y;
                        if (y > topY)
                        {
                            topY = y;
                        }
                        else if (y < bottomY)
                        {
                            bottomY = y;
                        }
                    }

                    float uiElementHeight = topY - bottomY;

                    for (int i = 0; i < count; i++)
                    {
                        UIVertex uiVertex = vertexList[i];
                        uiVertex.color = Color32.Lerp(mSecondColor, mFirstColor, (uiVertex.position.y - bottomY) / uiElementHeight);
                        vertexList[i] = uiVertex;
                    }
                }
                else if (mGradientType == JCS_GradientType.RIGHT_LEFT)
                {
                    float RightX = vertexList[0].position.x;
                    float LeftX = vertexList[0].position.x;

                    for (int i = 1; i < count; i++)
                    {
                        float x = vertexList[i].position.x;
                        if (x > RightX)
                        {
                            RightX = x;
                        }
                        else if (x < LeftX)
                        {
                            LeftX = x;
                        }
                    }

                    float uiElementWeight = LeftX - RightX;

                    for (int i = 0; i < count; i++)
                    {
                        UIVertex uiVertex = vertexList[i];
                        uiVertex.color = Color32.Lerp(mSecondColor, mFirstColor, (uiVertex.position.x - RightX) / uiElementWeight);
                        vertexList[i] = uiVertex;
                    }
                }
            }
        }

    }
}
