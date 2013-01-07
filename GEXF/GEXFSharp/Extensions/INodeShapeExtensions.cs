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

    public static class INodeShapeExtensions
    {


        #region HasShape(this myINodeShape)

        public static Boolean HasShape(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            return myINodeShape.Shape != NodeShapes.NOTSET;

        }

        #endregion

        #region ClearShape(this myINodeShape)

        public static INodeShape ClearShape(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            myINodeShape.Shape = NodeShapes.NOTSET;

            return myINodeShape;

        }

        #endregion

        #region GetShape(this myINodeShape)

        public static NodeShapes GetShape(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            return myINodeShape.Shape;

        }

        #endregion

        #region SetShape(this myINodeShape, myNodeShape)

        public static INodeShape SetShape(this INodeShape myINodeShape, NodeShapes myNodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            myINodeShape.Shape = myNodeShape;

            return myINodeShape;

        }

        #endregion


        #region HasUri(this myINodeShape)

        public static Boolean HasUri(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            return myINodeShape.Uri != null;

        }

        #endregion

        #region ClearUri(this myINodeShape)

        public static INodeShape ClearUri(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            myINodeShape.Uri = null;

            return myINodeShape;

        }

        #endregion

        #region GetUri(this myINodeShape)

        public static Uri GetUri(this INodeShape myINodeShape)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            return myINodeShape.Uri;

        }

        #endregion

        #region SetUri(this myINodeShape, myUri)

        public static INodeShape SetUri(this INodeShape myINodeShape, Uri myUri)
        {

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            if (myUri == null)
                throw new ArgumentNullException("myUri must not be null!");

            myINodeShape.Uri = myUri;

            return myINodeShape;

        }

        #endregion


    }

}
