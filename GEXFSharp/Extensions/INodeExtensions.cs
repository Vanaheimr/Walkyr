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

    public static class INodeExtensions
    {


        #region ClearLabel(this myINode)

        public static INode ClearLabel(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).ClearLabel() as INode;

        }

        #endregion

        #region SetLabel(this myINode, myLabel)

        public static INode SetLabel(this INode myINode, String myLabel)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).SetLabel(myLabel) as INode;

        }

        #endregion

        
        #region ClearColor(this myINode)

        public static INode ClearColor(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).ClearColor() as INode;

        }

        #endregion

        #region SetColor(this myINode, myColor)

        public static INode SetColor(this INode myINode, IColor myColor)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).SetColor(myColor) as INode;

        }

        #endregion

        #region SetColor(this myINode, myColorTriple)

        public static INode SetColor(this INode myINode, Tuple<Byte, Byte, Byte> myColorTriple)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).SetColor(myColorTriple) as INode;

        }

        #endregion

        #region SetColor(this myINode, myRed, myGreen, myBlue)

        public static INode SetColor(this INode myINode, Byte myRed, Byte myGreen, Byte myBlue)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return (myINode as IGraphElement).SetColor(myRed, myGreen, myBlue) as INode;

        }

        #endregion


        #region HasPosition(this myINode)

        public static Boolean HasPosition(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Position != null;

        }

        #endregion

        #region ClearPosition(this myINode)

        public static INode ClearPosition(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.Position = null;

            return myINode;

        }

        #endregion

        #region GetPosition(this myINode)

        public static IPosition GetPosition(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Position;

        }

        #endregion

        #region SetPosition(this myINode, myPosition)

        public static INode SetPosition(this INode myINode, IPosition myPosition)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            if (myPosition == null)
                throw new ArgumentNullException("myPosition must not be null!");

            myINode.Position = myPosition;

            return myINode;

        }

        #endregion


        #region HasSize(this myINode)

        public static Boolean HasSize(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Size != GEXFConstants.DefaultINodeSize;

        }

        #endregion

        #region ClearSize(this myINode)

        public static INode ClearSize(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.Size = GEXFConstants.DefaultINodeSize;

            return myINode;

        }

        #endregion

        #region GetSize(this myINode)

        public static float GetSize(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Size;

        }

        #endregion

        #region SetSize(this myINode, mySize)

        public static INode SetSize(this INode myINode, float mySize)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.Size = mySize;

            return myINode;

        }

        #endregion


        #region HasPID(this myINode)

        public static Boolean HasPID(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.PID.IsNotNullOrEmpty();

        }

        #endregion

        #region ClearPID(this myINode)

        public static INode ClearPID(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.PID = null;
            
            return myINode;

        }

        #endregion

        #region GetPID(this myINode)

        public static String GetPID(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.PID;

        }

        #endregion

        #region SetPID(this myINode, myPID)

        public static INode SetPID(this INode myINode, String myPID)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            if (myPID.IsNullOrEmpty())
                throw new ArgumentNullException("myPID must not be null!");

            myINode.PID = myPID;

            return myINode;

        }

        #endregion


        #region HasShape(this myINode)

        public static Boolean HasShape(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Shape != null;

        }

        #endregion

        #region ClearShape(this myINode)

        public static INode ClearShape(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.Shape = null;
            
            return myINode;

        }

        #endregion

        #region GetShape(this myINode)

        public static INodeShape GetShape(this INode myINode)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            return myINode.Shape;

        }

        #endregion

        #region SetShape(this myINode, myNodeShape)

        public static INode SetShape(this INode myINode, NodeShapes myNodeShape)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            myINode.Shape = new NodeShape(myNodeShape);

            return myINode;

        }

        #endregion

        #region SetShape(this myINode, myINodeShape)

        public static INode SetShape(this INode myINode, INodeShape myINodeShape)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            myINode.Shape = myINodeShape;

            return myINode;

        }

        #endregion


        #region HasEdgeTo(this myINode, myId)

        public static Boolean HasEdgeTo(this INode myINode, String myId)
        {

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            if (myId.IsNullOrEmpty())
                throw new ArgumentNullException("myId must not be null or empty!");

            foreach (var _IEdge in myINode.Edges)
                if (_IEdge.Target.Id == myId)
                    return true;

            return false;

        }

        #endregion


    }

}
