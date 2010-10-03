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
using System.Collections.Generic;

#endregion

namespace GEXFSharp
{

    public class Graph : ADynamic<Graph>, IGraph
    {

        #region Properties

        public IDType   IDType          { get; set; }
	    public Mode     Mode            { get; set; }
	    public TimeType TimeType        { get; set; }
        public EdgeType DefaultEdgeType { get; set; }

        #region AttributeLists

        private List<IAttributeList> _AttributeLists;

        public IEnumerable<IAttributeList> AttributeLists
        {
            get
            {
                return _AttributeLists;
            }
        }

        #endregion

        #region Nodes

        private Dictionary<String, INode> _Nodes;

        public IEnumerable<INode> Nodes
        {
            get
            {
                return _Nodes.Values;
            }
        }

        #endregion

        #region Edges

        public IEnumerable<IEdge> Edges
        {

            get
            {

                foreach (var _INode in _Nodes.Values)
                    foreach (var _Edge in _INode.Edges)
                        yield return _Edge;

            }

        }

        #endregion

        #endregion

        #region Constructor(s)

        #region Graph()

        public Graph()
        {

            IDType          = IDType.STRING;
            Mode            = Mode.STATIC;
            TimeType        = TimeType.DATE;
            DefaultEdgeType = EdgeType.DIRECTED;

		    _Nodes          = new Dictionary<String, INode>();
		    _AttributeLists = new List<IAttributeList>();

	    }

        #endregion

        #endregion


        #region AddNode(myINode)

        public INode AddNode(INode myINode)
        {

            if (myINode != null)
                _Nodes.Add(myINode.Id, myINode);

            return myINode;

        }

        #endregion

        #region FindNode(myId)

        public INode FindNode(String myId)
        {

            #region Inital checks

            if (myId.IsNullOrEmpty())
                throw new ArgumentNullException("myId must not be null or empty!");

            #endregion

            INode _INode = null;

            _Nodes.TryGetValue(myId, out _INode);
            
            return _INode;

        }

        #endregion


        #region GetSelf()

        protected override Graph GetSelf()
        {
            return this;
        }

        #endregion

        #region ToString()

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

    }

}
