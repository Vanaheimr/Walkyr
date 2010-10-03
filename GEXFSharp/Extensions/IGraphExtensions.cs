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
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

#endregion

namespace GEXFSharp
{

    public static class IGraphExtensions
    {


        #region GetDefaultEdgeType(this myIGraph)

        public static EdgeType GetDefaultEdgeType(this IGraph myIGraph)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.DefaultEdgeType;

        }

        #endregion

        #region SetDefaultEdgeType(this myIGraph, myDefaultEdgeType)

        public static IGraph SetDefaultEdgeType(this IGraph myIGraph, EdgeType myDefaultEdgeType)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            myIGraph.DefaultEdgeType = myDefaultEdgeType;

            return myIGraph;

        }

        #endregion


        #region GetIDType(this myIGraph)

        public static IDType GetIDType(this IGraph myIGraph)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.IDType;

        }

        #endregion

        #region SetIDType(this myIGraph, myIDType)

        public static IGraph SetIDType(this IGraph myIGraph, IDType myIDType)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            myIGraph.IDType = myIDType;

            return myIGraph;

        }

        #endregion


        #region GetMode(this myIGraph)

        public static Mode GetMode(this IGraph myIGraph)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.Mode;

        }

        #endregion

        #region SetMode(this myIGraph, myMode)

        public static IGraph SetMode(this IGraph myIGraph, Mode myMode)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            myIGraph.Mode = myMode;

            return myIGraph;

        }

        #endregion


        #region GetTimeType(this myIGraph)

        public static TimeType GetTimeType(this IGraph myIGraph)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.TimeType;

        }

        #endregion

        #region SetTimeType(this myIGraph, myTimeType)

        public static IGraph SetTimeType(this IGraph myIGraph, TimeType myTimeType)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            myIGraph.TimeType = myTimeType;

            return myIGraph;

        }

        #endregion


        #region AddNode(this myIGraph)

        public static INode AddNode(this IGraph myIGraph)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");
            
            return myIGraph.AddNode(new Node());

        }

        #endregion

        #region AddNode(this myIGraph, myId)

        public static INode AddNode(this IGraph myIGraph, String myId)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            if (myId.IsNullOrEmpty())
                throw new ArgumentNullException("myId must not be null or empty!");

            return myIGraph.AddNode(new Node(myId));

        }

        #endregion

        #region AddNode(this myIGraph, myInt32Id)

        public static INode AddNode(this IGraph myIGraph, Int32 myInt32Id)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.AddNode(myInt32Id.ToString());

        }

        #endregion

        #region AddNode(this myIGraph, myUInt32Id)

        public static INode AddNode(this IGraph myIGraph, UInt32 myUInt32Id)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.AddNode(myUInt32Id.ToString());

        }

        #endregion

        #region AddNode(this myIGraph, myInt64Id)

        public static INode AddNode(this IGraph myIGraph, Int64 myInt64Id)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.AddNode(myInt64Id.ToString());

        }

        #endregion

        #region AddNode(this myIGraph, myUInt64Id)

        public static INode AddNode(this IGraph myIGraph, UInt64 myUInt64Id)
        {

            if (myIGraph == null)
                throw new ArgumentNullException("myIGraph must not be null!");

            return myIGraph.AddNode(myUInt64Id.ToString());

        }

        #endregion


        #region FindNode(this myIGraph, myNodeSelector)

        public static INode FindNode(this IGraph myIGraph, Func<INode, Boolean> myNodeSelector)
        {

            foreach (var _INode in myIGraph.Nodes)
            {

                if (myNodeSelector == null)
                    return _INode;
                
                else
                    if (myNodeSelector(_INode))
                        return _INode;

            }

            return null;

        }

        #endregion

        #region FindNodes(this myIGraph, myNodeSelector)

        public static IEnumerable<INode> FindNodes(this IGraph myIGraph, Func<INode, Boolean> myNodeSelector)
        {

            foreach (var _INode in myIGraph.Nodes)
            {

                if (myNodeSelector == null)
                    yield return _INode;

                else
                    if (myNodeSelector(_INode))
                        yield return _INode;

            }

        }

        #endregion


    }

}
