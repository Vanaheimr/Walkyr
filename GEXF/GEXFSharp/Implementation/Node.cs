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

    public class Node : ASliceableDatum<Node>, INode
    {

        #region Properties

        public String       Id          { get; protected set; }
        public String       Label       { get; set; }
        public IColor       Color       { get; set; }
        public IPosition    Position    { get; set; }
        public float        Size        { get; set; }
        public String       PID         { get; set; }
        public INodeShape   Shape       { get; set; }

        #region Edges

        private readonly List<IEdge> _Edges;

        public IEnumerable<IEdge> Edges
        {
            get
            {
                return _Edges;
            }
        }

        #endregion

        #region Neighbors

        public IEnumerable<INode> Neighbors
        {
            get
            {
                foreach (var _IEdge in _Edges)
                    yield return _IEdge.Target;
            }
        }

        #endregion

        #endregion

        #region Constructor(s)

        #region Node()

        public Node()
            : this(Guid.NewGuid().ToString())
        {
        }

        #endregion

        #region Node(myId)

        public Node(String myId, String myLabel = null)
        {

            if (myId.IsNullOrEmpty())
                throw new ArgumentNullException("myId must not be null or empty!");

            Id     = myId;
            Label  = myLabel ?? myId;
            _Edges = new List<IEdge>();

        }

        #endregion

        #endregion


        #region ConnectTo(myINodeTarget)

        public IEdge ConnectTo(INode myINodeTarget)
        {
            return ConnectTo(Guid.NewGuid().ToString(), myINodeTarget);
        }

        #endregion

        #region ConnectTo(myEdgeId, myINodeTarget)

        public IEdge ConnectTo(String myEdgeId, INode myINodeTarget)
        {

            #region Initial checks

            if (myEdgeId.IsNullOrEmpty())
                throw new ArgumentNullException("myEdgeId must not be null or empty!");

            if (myINodeTarget == null)
                throw new ArgumentNullException("myINodeTarget must not be null or empty!");

            #endregion

            var __Edge = new Edge(myEdgeId, this, myINodeTarget);
            _Edges.Add(__Edge);
            return __Edge;

        }

        #endregion


        #region GetSelf()

        protected override Node GetSelf()
        {
            return this;
        }

        #endregion

        #region ToString()

        public override String ToString()
        {
            return String.Format("{0} [{1}]", Id, Label);
        }

        #endregion

    }

}