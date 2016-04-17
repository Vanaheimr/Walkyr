/*
 * Copyright (c) 2010-2015, Achim 'ahzf' Friedland <achim@graphdefined.org>
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
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Balder;

#endregion

namespace org.GraphDefined.Vanaheimr.Walkyr.GEXF
{

    public static class GEXFExporterExtentions
    {

        public static GEXFExporter<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                   TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                   TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                   TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>

                          ToGEXF<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                 TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                 TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                 TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>(

                              this IReadOnlyGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                                 TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                                 TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                                 TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph,

                              IEnumerable<TKeyVertex> IncludeVertexAttributes,
                              IEnumerable<TKeyEdge>   IncludeEdgeAttributes)

            where TIdVertex        : IEquatable<TIdVertex>,       IComparable<TIdVertex>,       IComparable, TValueVertex
            where TIdEdge          : IEquatable<TIdEdge>,         IComparable<TIdEdge>,         IComparable, TValueEdge
            where TIdMultiEdge     : IEquatable<TIdMultiEdge>,    IComparable<TIdMultiEdge>,    IComparable, TValueMultiEdge
            where TIdHyperEdge     : IEquatable<TIdHyperEdge>,    IComparable<TIdHyperEdge>,    IComparable, TValueHyperEdge

            where TRevIdVertex     : IEquatable<TRevIdVertex>,    IComparable<TRevIdVertex>,    IComparable, TValueVertex
            where TRevIdEdge       : IEquatable<TRevIdEdge>,      IComparable<TRevIdEdge>,      IComparable, TValueEdge
            where TRevIdMultiEdge  : IEquatable<TRevIdMultiEdge>, IComparable<TRevIdMultiEdge>, IComparable, TValueMultiEdge
            where TRevIdHyperEdge  : IEquatable<TRevIdHyperEdge>, IComparable<TRevIdHyperEdge>, IComparable, TValueHyperEdge

            where TVertexLabel     : IEquatable<TVertexLabel>,    IComparable<TVertexLabel>,    IComparable, TValueVertex
            where TEdgeLabel       : IEquatable<TEdgeLabel>,      IComparable<TEdgeLabel>,      IComparable, TValueEdge
            where TMultiEdgeLabel  : IEquatable<TMultiEdgeLabel>, IComparable<TMultiEdgeLabel>, IComparable, TValueMultiEdge
            where THyperEdgeLabel  : IEquatable<THyperEdgeLabel>, IComparable<THyperEdgeLabel>, IComparable, TValueHyperEdge

            where TKeyVertex       : IEquatable<TKeyVertex>,      IComparable<TKeyVertex>,      IComparable
            where TKeyEdge         : IEquatable<TKeyEdge>,        IComparable<TKeyEdge>,        IComparable
            where TKeyMultiEdge    : IEquatable<TKeyMultiEdge>,   IComparable<TKeyMultiEdge>,   IComparable
            where TKeyHyperEdge    : IEquatable<TKeyHyperEdge>,   IComparable<TKeyHyperEdge>,   IComparable

        {

            return new GEXFExporter<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                    TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                    TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                    TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge>(Graph, IncludeVertexAttributes, IncludeEdgeAttributes);

        }

    }


    public class GEXFExporter<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
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

        where TVertexLabel     : IEquatable<TVertexLabel>,    IComparable<TVertexLabel>,    IComparable, TValueVertex
        where TEdgeLabel       : IEquatable<TEdgeLabel>,      IComparable<TEdgeLabel>,      IComparable, TValueEdge
        where TMultiEdgeLabel  : IEquatable<TMultiEdgeLabel>, IComparable<TMultiEdgeLabel>, IComparable, TValueMultiEdge
        where THyperEdgeLabel  : IEquatable<THyperEdgeLabel>, IComparable<THyperEdgeLabel>, IComparable, TValueHyperEdge

        where TKeyVertex       : IEquatable<TKeyVertex>,      IComparable<TKeyVertex>,      IComparable
        where TKeyEdge         : IEquatable<TKeyEdge>,        IComparable<TKeyEdge>,        IComparable
        where TKeyMultiEdge    : IEquatable<TKeyMultiEdge>,   IComparable<TKeyMultiEdge>,   IComparable
        where TKeyHyperEdge    : IEquatable<TKeyHyperEdge>,   IComparable<TKeyHyperEdge>,   IComparable

    {

        // <?xml version="1.0" encoding="UTF-8"?>
        // <gexf xmlns="http://www.gexf.net/1.2draft" version="1.2">
        //     <meta lastmodifieddate="2009-03-20">
        //         <creator>Gexf.net</creator>
        //         <description>A hello world! file</description>
        //     </meta>
        //     <graph mode="static" defaultedgetype="directed">
        //         <nodes>
        //             <node id="0" label="Hello" />
        //             <node id="1" label="Word" />
        //         </nodes>
        //         <edges>
        //             <edge id="0" source="0" target="1" />
        //         </edges>
        //     </graph>
        // </gexf>

        #region Data

        private XDocument GEXFGraphXML;

        public  static readonly XNamespace GEXFNS = XNamespace.Get("http://www.gexf.net/1.2draft");

        #endregion


        public GEXFExporter(IReadOnlyGenericPropertyGraph<TIdVertex,    TRevIdVertex,    TVertexLabel,    TKeyVertex,    TValueVertex,
                                                          TIdEdge,      TRevIdEdge,      TEdgeLabel,      TKeyEdge,      TValueEdge,
                                                          TIdMultiEdge, TRevIdMultiEdge, TMultiEdgeLabel, TKeyMultiEdge, TValueMultiEdge,
                                                          TIdHyperEdge, TRevIdHyperEdge, THyperEdgeLabel, TKeyHyperEdge, TValueHyperEdge> Graph,

                            IEnumerable<TKeyVertex> IncludeVertexAttributes,
                            IEnumerable<TKeyEdge>   IncludeEdgeAttributes)

        {

            var NodeAttr2Ids    = new Dictionary<UInt16,     TKeyVertex>();
            IncludeVertexAttributes.ForEachCounted((s, i) => NodeAttr2Ids.Add((UInt16) (i - 1), s));

            var add = (UInt64) IncludeVertexAttributes.Count();

            var EdgeAttr2Ids    = new Dictionary<UInt16,   TKeyEdge>();
            IncludeEdgeAttributes.  ForEachCounted((s, i) => EdgeAttr2Ids.Add((UInt16) (i - 1 + add), s));


            this.GEXFGraphXML   = new XDocument(
                                      new XDeclaration("1.0", "utf-8", "no"),

                                      new XElement("gexf",
                                          new XAttribute(XNamespace.Xmlns + "gexfns", GEXFNS),
                                          new XAttribute("version", "1.2"),

                                          new XElement("graph",
                                              new XAttribute("mode",             "static"),
                                              new XAttribute("defaultedgetype",  "directed"),

                                              new XElement("attributes",
                                                  new XAttribute("class", "node"),

                                                  NodeAttr2Ids.Select(node => new XElement("attribute",
                                                                                  new XAttribute("id",     node.Key.   ToString()),
                                                                                  new XAttribute("title",  node.Value. ToString()),
                                                                                  new XAttribute("type",   "string")
                                                                              ))

                                              ),

                                              new XElement("attributes",
                                                  new XAttribute("class", "edge"),

                                                  EdgeAttr2Ids.Select(edge => new XElement("attribute",
                                                                                  new XAttribute("id",     edge.Key.   ToString()),
                                                                                  new XAttribute("title",  edge.Value. ToString()),
                                                                                  new XAttribute("type",   "string")
                                                                              ))

                                              ),

                                              new XElement("nodes",
                                                  Graph.Vertices().Select(vertex => new XElement("node",
                                                                 new XAttribute("id",     vertex.Id.ToString()),
                                                                 new XAttribute("label",  vertex.Label.ToString()),

                                                                 new XElement("attrvalues",
                                                                     NodeAttr2Ids.Select(vp => vertex[vp.Value] != null
                                                                                                   ? new XElement("attrvalue",
                                                                                                         new XAttribute("for", vp.Key),
                                                                                                         new XAttribute("value", vertex[vp.Value].ToString())
                                                                                                     )
                                                                                                   : null).
                                                                     Where(v => v != null)

                                                                 )
                                                            ))),

                                              new XElement("edges",
                                                  Graph.Edges().   Select(edge   => new XElement("edge",
                                                                 new XAttribute("id",      edge.Id.           ToString()),
                                                                 new XAttribute("source",  edge.OutVertex.Id. ToString()),
                                                                 new XAttribute("target",  edge.InVertex. Id. ToString()),
                                                                 new XAttribute("type",    "directed"                   ),

                                                                 new XElement("attrvalues",
                                                                     EdgeAttr2Ids.Select(ep => edge[ep.Value] != null
                                                                                                   ? new XElement("attrvalue",
                                                                                                         new XAttribute("for",    ep.Key),
                                                                                                         new XAttribute("value",  edge[ep.Value].ToString())
                                                                                                     )
                                                                                                   : null).
                                                                     Where(v => v != null)

                                                                 )
                                                            )))

                                          )

                                      )

                                  );


            var GEXFNodes  = GEXFGraphXML.Descendants("nodes").FirstOrDefault();
            var GEXFEdges  = GEXFGraphXML.Descendants("edges").FirstOrDefault();

        }


        public override String ToString()
        {
            return GEXFGraphXML.ToString();
        }

    }

}
