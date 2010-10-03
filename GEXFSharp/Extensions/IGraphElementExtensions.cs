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

    public static class IGraphElementExtensions
    {


        #region GetId(this myIGraphElement)

        public static String GetId(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            return myIGraphElement.Id;

        }

        #endregion


        #region HasLabel(this myIGraphElement)

        public static Boolean HasLabel(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            return myIGraphElement.Label.IsNotNullOrEmpty();

        }

        #endregion

        #region ClearLabel(this myIGraphElement)

        public static IGraphElement ClearLabel(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            myIGraphElement.Label = null;

            return myIGraphElement;

        }

        #endregion

        #region GetLabel(this myIGraphElement)

        public static String GetLabel(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            return myIGraphElement.Label;

        }

        #endregion

        #region SetLabel(this myIGraphElement, myLabel)

        public static IGraphElement SetLabel(this IGraphElement myIGraphElement, String myLabel)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            if (myLabel.IsNullOrEmpty())
                throw new ArgumentNullException("myLabel must not be null or empty!");

            myIGraphElement.Label = myLabel;

            return myIGraphElement;

        }

        #endregion


        #region HasColor(this myIGraphElement)

        public static Boolean HasColor(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            return myIGraphElement.Color != null;

        }

        #endregion

        #region ClearColor(this myIGraphElement)

        public static IGraphElement ClearColor(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            myIGraphElement.Color = null;

            return myIGraphElement;

        }

        #endregion

        #region GetColor(this myIGraphElement)

        public static IColor GetColor(this IGraphElement myIGraphElement)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            return myIGraphElement.Color;

        }

        #endregion

        #region SetColor(this myIGraphElement, myColor)

        public static IGraphElement SetColor(this IGraphElement myIGraphElement, IColor myColor)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            if (myColor == null)
                throw new ArgumentNullException("myColor must not be null!");

            myIGraphElement.Color = myColor;

            return myIGraphElement;

        }

        #endregion

        #region SetColor(this myIGraphElement, myColorTriple)

        public static IGraphElement SetColor(this IGraphElement myIGraphElement, Tuple<Byte, Byte, Byte> myColorTriple)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            if (myColorTriple == null)
                throw new ArgumentNullException("myColorTriple must not be null!");

            myIGraphElement.Color = new Color(myColorTriple);

            return myIGraphElement;

        }

        #endregion

        #region SetColor(this myIGraphElement, myRed, myGreen, myBlue)

        public static IGraphElement SetColor(this IGraphElement myIGraphElement, Byte myRed, Byte myGreen, Byte myBlue)
        {

            if (myIGraphElement == null)
                throw new ArgumentNullException("myIGraphElement must not be null!");

            myIGraphElement.Color = new Color(myRed, myGreen, myBlue);

            return myIGraphElement;

        }

        #endregion


    }

}
