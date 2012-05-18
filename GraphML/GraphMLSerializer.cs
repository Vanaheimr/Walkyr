/*
 * Copyright (c) 2010-2012, Achim 'ahzf' Friedland <achim@graph-database.org>
 * This file is part of Walkyr <http://www.github.com/Vanaheimr/Walkyr>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using de.ahzf.Illias.Commons;
using de.ahzf.Blueprints.PropertyGraphs;

#endregion

namespace de.ahzf.Vanaheimr.Walkyr.GraphML
{

    public class GraphMLSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                   TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                   TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                   TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

          : IGraphSerializer<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                             TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                             TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                             TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

        where TIdVertex        : IEquatable<TIdVertex>,       IComparable<TIdVertex>,       IComparable, TValueVertex
        where TIdEdge          : IEquatable<TIdEdge>,         IComparable<TIdEdge>,         IComparable, TValueEdge
        where TIdMultiEdge     : IEquatable<TIdMultiEdge>,    IComparable<TIdMultiEdge>,    IComparable, TValueMultiEdge
        where TIdHyperEdge     : IEquatable<TIdHyperEdge>,    IComparable<TIdHyperEdge>,    IComparable, TValueHyperEdge

        where TRevIdVertex     : IEquatable<TRevIdVertex>,    IComparable<TRevIdVertex>,    IComparable, TValueVertex
        where TRevIdEdge       : IEquatable<TRevIdEdge>,      IComparable<TRevIdEdge>,      IComparable, TValueEdge
        where TRevIdMultiEdge  : IEquatable<TRevIdMultiEdge>, IComparable<TRevIdMultiEdge>, IComparable, TValueMultiEdge
        where TRevIdHyperEdge  : IEquatable<TRevIdHyperEdge>, IComparable<TRevIdHyperEdge>, IComparable, TValueHyperEdge

        where TVertexLabel     : IEquatable<TVertexLabel>,    IComparable<TVertexLabel>,    IComparable
        where TEdgeLabel       : IEquatable<TEdgeLabel>,      IComparable<TEdgeLabel>,      IComparable
        where TMultiEdgeLabel  : IEquatable<TMultiEdgeLabel>, IComparable<TMultiEdgeLabel>, IComparable
        where THyperEdgeLabel  : IEquatable<THyperEdgeLabel>, IComparable<THyperEdgeLabel>, IComparable

        where TKeyVertex       : IEquatable<TKeyVertex>,      IComparable<TKeyVertex>,      IComparable
        where TKeyEdge         : IEquatable<TKeyEdge>,        IComparable<TKeyEdge>,        IComparable
        where TKeyMultiEdge    : IEquatable<TKeyMultiEdge>,   IComparable<TKeyMultiEdge>,   IComparable
        where TKeyHyperEdge    : IEquatable<TKeyHyperEdge>,   IComparable<TKeyHyperEdge>,   IComparable

    {

        public string ToStringRepresentation(Blueprints.PropertyGraphs.IGenericPropertyGraph<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph)
        {

            var StringBuilder = new StringBuilder();

            StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            StringBuilder.AppendLine("<graphml xmlns=\"http://graphml.graphdrawing.org/xmlns\"");
            StringBuilder.AppendLine("    xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
            StringBuilder.AppendLine("    xsi:schemaLocation=\"http://graphml.graphdrawing.org/xmlns");
            StringBuilder.AppendLine("     http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd\">");
            StringBuilder.AppendLine("  <graph id=\"" + Graph.Id + "\" edgedefault=\"directed\">");

            Graph.Vertices().ForEach(Vertex => StringBuilder.AppendLine(this.ToStringRepresentation(Vertex)));
            Graph.Edges()   .ForEach(Edge   => StringBuilder.AppendLine(this.ToStringRepresentation(Edge)));

            StringBuilder.AppendLine("  </graph>");
            StringBuilder.AppendLine("</graphml>");

            return StringBuilder.ToString();

        }

        public byte[] ToBinaryRepresentation(Blueprints.PropertyGraphs.IGenericPropertyGraph<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph)
        {
            throw new NotImplementedException();
        }

        public string ToStringRepresentation(Blueprints.PropertyGraphs.IGenericPropertyVertex<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Vertex)
        {
            return "<node id=\"" + Vertex.Id + "\" />";
        }

        public byte[] ToBinaryRepresentation(Blueprints.PropertyGraphs.IGenericPropertyVertex<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Vertex)
        {
            throw new NotImplementedException();
        }

        public string ToStringRepresentation(Blueprints.PropertyGraphs.IGenericPropertyEdge<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Edge)
        {
            return "<edge id=\"" + Edge.Id + "\" directed=\"true\" source=\"" + Edge.OutVertex.Id + "\" target=\"" + Edge.InVertex.Id + "\" />";
        }

        public byte[] ToBinaryRepresentation(Blueprints.PropertyGraphs.IGenericPropertyEdge<TIdVertex, TRevIdVertex, TVertexLabel, TKeyVertex, TValueVertex, TIdEdge, TRevIdEdge, TEdgeLabel, TKeyEdge, TValueEdge, TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge, TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Edge)
        {
            throw new NotImplementedException();
        }

    }

}
