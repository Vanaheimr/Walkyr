/*
 *  Licensed to the Apache Software Foundation (ASF) under one
 *  or more contributor license agreements.  See the NOTICE file
 *  distributed with this work for additional information
 *  regarding copyright ownership.  The ASF licenses this file
 *  to you under the Apache License, Version 2.0 (the
 *  "License"); you may not use this file except in compliance
 *  with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing,
 *  software distributed under the License is distributed on an
 *  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 *  KIND, either express or implied.  See the License for the
 *  specific language governing permissions and limitations
 *  under the License.
 *
 *  Autor: Achim Friedland <achim@graph-database.org>, 2010
 *
 */

#region Usings

using System;
using System.Text;

#endregion

namespace GEXFSharp
{

    public static class IEdgeExtensions
    {


        #region GetSource(this myIEdge)

        public static INode GetSource(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            if (myIEdge.Source == null)
                throw new ArgumentNullException("myIEdge.Source must not be null!");

            return myIEdge.Source;

        }

        #endregion

        #region GetSourceId(this myIEdge)

        public static String GetSourceId(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            if (myIEdge.Source == null)
                throw new ArgumentNullException("myIEdge.Source must not be null!");

            return myIEdge.Source.Id;

        }

        #endregion


        #region GetTarget(this myIEdge)

        public static INode GetTarget(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            if (myIEdge.Target == null)
                throw new ArgumentNullException("myIEdge.Target must not be null!");

            return myIEdge.Target;

        }

        #endregion

        #region GetTargetId(this myIEdge)

        public static String GetTargetId(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            if (myIEdge.Target == null)
                throw new ArgumentNullException("myIEdge.Target must not be null!");

            return myIEdge.Target.Id;

        }

        #endregion


        #region GetEdgeType(this myIEdge)

        public static EdgeType GetEdgeType(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.EdgeType;

        }

        #endregion

        #region SetEdgeType(this myIEdge, myEdgeType)

        public static IEdge SetEdgeType(this IEdge myIEdge, EdgeType myEdgeType)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.EdgeType = myEdgeType;

            return myIEdge;

        }

        #endregion


        // IGraphElement

        #region ClearLabel(this myIEdge)

        public static IEdge ClearLabel(this IEdge myIEdge)
        {
            return (myIEdge as IGraphElement).ClearLabel() as IEdge;
        }

        #endregion

        #region SetLabel(this myIEdge, myLabel)

        public static IEdge SetLabel(this IEdge myIEdge, String myLabel)
        {
            return (myIEdge as IGraphElement).SetLabel(myLabel) as IEdge;
        }

        #endregion


        #region ClearColor(this myIEdge)

        public static IEdge ClearColor(this IEdge myIEdge)
        {
            return (myIEdge as IGraphElement).ClearColor() as IEdge;
        }

        #endregion

        #region SetColor(this myIEdge, myColor)

        public static IEdge SetColor(this IEdge myIEdge, IColor myColor)
        {
            return (myIEdge as IGraphElement).SetColor(myColor) as IEdge;
        }

        #endregion

        #region SetColor(this myIEdge, myColorTriple)

        public static IEdge SetColor(this IEdge myIEdge, Tuple<Byte, Byte, Byte> myColorTriple)
        {
            return (myIEdge as IGraphElement).SetColor(myColorTriple) as IEdge;
        }

        #endregion

        #region SetColor(this myIEdge, myRed, myGreen, myBlue)

        public static IEdge SetColor(this IEdge myIEdge, Byte myRed, Byte myGreen, Byte myBlue)
        {
            return (myIEdge as IGraphElement).SetColor(myRed, myGreen, myBlue) as IEdge;
        }

        #endregion


        // IEgde attributes

        #region HasWeight(this myIEdge)

        public static Boolean HasWeight(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Weight != GEXFConstants.DefaultIEdgeWeight;

        }

        #endregion

        #region ClearWeight(this myIEdge)

        public static IEdge ClearWeight(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Weight = GEXFConstants.DefaultIEdgeWeight;

            return myIEdge;

        }

        #endregion

        #region GetWeight(this myIEdge)

        public static float GetWeight(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Weight;

        }

        #endregion

        #region SetWeight(this myIEdge, myWeight)

        public static IEdge SetWeight(this IEdge myIEdge, float myWeight)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Weight = myWeight;

            return myIEdge;

        }

        #endregion


        #region HasThickness(this myIEdge)

        public static Boolean HasThickness(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Thickness != GEXFConstants.DefaultIEdgeThickness;

        }

        #endregion

        #region ClearThickness(this myIEdge)

        public static IEdge ClearThickness(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Thickness = GEXFConstants.DefaultIEdgeThickness;

            return myIEdge;

        }

        #endregion

        #region GetThickness(this myIEdge)

        public static float GetThickness(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Thickness;

        }

        #endregion

        #region SetThickness(this myIEdge, myThickness)

        public static IEdge SetThickness(this IEdge myIEdge, float myThickness)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Thickness = myThickness;

            return myIEdge;

        }

        #endregion


        #region HasShape(this myIEdge)

        public static Boolean HasShape(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Shape != EdgeShape.NOTSET;

        }

        #endregion

        #region ClearShape(this myIEdge)

        public static IEdge ClearShape(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Shape = EdgeShape.NOTSET;
            
            return myIEdge;

        }

        #endregion

        #region GetShape(this myIEdge)

        public static EdgeShape GetShape(this IEdge myIEdge)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            return myIEdge.Shape;

        }

        #endregion

        #region SetShape(this myIEdge, myEdgeShape)

        public static IEdge SetShape(this IEdge myIEdge, EdgeShape myEdgeShape)
        {

            if (myIEdge == null)
                throw new ArgumentNullException("myIEdge must not be null!");

            myIEdge.Shape = myEdgeShape;

            return myIEdge;

        }

        #endregion


    }

}
