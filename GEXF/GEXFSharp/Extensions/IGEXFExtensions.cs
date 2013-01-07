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

    public static class IGEXFExtensions
    {

        #region Statics

        public static XNamespace gephi_ns       = "http://www.gexf.net/1.1draft";
        public static XNamespace viz            = "http://www.gexf.net/1.1draft/viz";
        public static XNamespace xsi            = "http://www.w3.org/2001/XMLSchema-instance";
        public static XNamespace schemaLocation = "http://www.gexf.net/1.1draft http://www.gexf.net/1.1draft/gexf.xsd";

        #endregion


        #region HasVariant(this myIGEXF)

        public static Boolean HasVariant(this IGEXF myIGEXF)
        {

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            return myIGEXF.Variant != null;

        }

        #endregion

        #region ClearVariant(this myIGEXF)

        public static IGEXF ClearVariant(this IGEXF myIGEXF)
        {

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            myIGEXF.Variant = null;
            
            return myIGEXF;

        }

        #endregion

        #region HasVisualization(this myIGEXF)

        public static Boolean HasVisualization(this IGEXF myIGEXF)
        {

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            return myIGEXF.Visualization;

        }

        #endregion


        #region ToXML(this myIGEXF)

        /// <summary>
        /// Translates the given IGEXF graph to its GEXF v1.1 XML representation
        /// </summary>
        /// <returns>A XDocument</returns>
        public static XDocument ToXML(this IGEXF myIGEXF)
        {

            #region Initial checks

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            #endregion

            var _XDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));

            var _gexf = new XElement(gephi_ns + "gexf",
                            new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                            new XAttribute(xsi + "schemaLocation",   schemaLocation.NamespaceName),
                            new XAttribute("version",                myIGEXF.Version ?? ""));

            var _meta = new XElement(gephi_ns + "meta",
                            new XAttribute("lastmodifieddate",       myIGEXF.Metadata.LastModified.ToFormatedString("yyyy-MM-dd")),
                            new XElement  (gephi_ns + "creator",     myIGEXF.Metadata.Creator ?? ""),
                            new XElement  (gephi_ns + "description", myIGEXF.Metadata.Description ?? ""));

            if (myIGEXF.Metadata.Keywords.IsNotNullOrEmpty())
                _meta.Add(new XElement(gephi_ns + "keywords", myIGEXF.Metadata.Keywords.ToCommaSeperatedList()));

            var _graph = new XElement(gephi_ns + "graph",
                            new XAttribute("mode",                   myIGEXF.Graph.Mode.ToString().ToLower()),
                            new XAttribute("defaultedgetype",        myIGEXF.Graph.DefaultEdgeType.ToString().ToLower()),

                            //new XElement("attributes", new XAttribute("class", "node")),    // optional!
                            //new XElement("attributes", new XAttribute("class", "edge")),    // optional!
                            myIGEXF.Graph.Nodes.ToXML(_gexf),
                            myIGEXF.Graph.Edges.ToXML(_gexf)

            );

            _XDocument.Add(_gexf);
            _gexf.Add(_meta);
            _gexf.Add(_graph);

            return _XDocument;

        }

        #endregion

        #region ToXML(this myINodes, myGEXFXElement)

        public static XElement ToXML(this IEnumerable<INode> myINodes, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myINodes == null)
                throw new ArgumentNullException("myINodes must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            var _Nodes = new XElement(gephi_ns + "nodes");

            // <node id="0" label="Hello world!" />
            if (myINodes != null)
                foreach (var _INode in myINodes)
                {

                    var _XMLNode = new XElement(gephi_ns + "node",
                                      new XAttribute("id",    _INode.Id),      // mandatory!
                                      new XAttribute("label", _INode.Label));  // mandatory!

                    if (_INode.HasColor())
                        _XMLNode.Add(_INode.Color.ToXML(myGEXFXElement));

                    if (_INode.HasSize())
                        _XMLNode.Add(_INode.SizeToXML(myGEXFXElement));

                    if (_INode.HasShape())
                        _XMLNode.Add(_INode.Shape.ToXML(myGEXFXElement));

                    _Nodes.Add(_XMLNode);

                }

            return _Nodes;

        }

        #endregion

        #region ToXML(this myIEdges, myGEXFXElement)

        public static XElement ToXML(this IEnumerable<IEdge> myIEdges, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myIEdges == null)
                throw new ArgumentNullException("myIEdges must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            var _Edges = new XElement(gephi_ns + "edges");

            // <edge id="0" source="0" target="1" />
            if (myIEdges != null)
                foreach (var _IEdge in myIEdges)
                {

                    var _XMLEdge = new XElement(gephi_ns + "edge",
                                      new XAttribute("id",     _IEdge.Id),            // mandatory!
                                      new XAttribute("source", _IEdge.Source.Id),     // mandatory!
                                      new XAttribute("target", _IEdge.Target.Id));    // mandatory!
                
                    if (_IEdge.HasColor())
                        _XMLEdge.Add(_IEdge.Color.ToXML(myGEXFXElement));

                    if (_IEdge.HasLabel())
                        _XMLEdge.Add(new XAttribute("label", _IEdge.Label));

                    if (_IEdge.HasWeight())
                        _XMLEdge.Add(new XAttribute("weight", _IEdge.Weight));

                    _Edges.Add(_XMLEdge);

                }

            return _Edges;

        }

        #endregion


        #region SizeToXML(this myINode, myGEXFXElement)

        public static XElement SizeToXML(this INode myINode, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myINode == null)
                throw new ArgumentNullException("myINode must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            if (myGEXFXElement.Attribute(XNamespace.Xmlns + "viz") == null)
                myGEXFXElement.Add(new XAttribute(XNamespace.Xmlns + "viz", viz.NamespaceName));

            return new XElement(viz + "size", new XAttribute("value", myINode.Size.ToString("0.0######").Replace(',', '.')));

        }

        #endregion

        #region ToXML(this myIColor, myGEXFXElement)

        public static XElement ToXML(this IColor myIColor, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myIColor == null)
                throw new ArgumentNullException("myIColor must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            if (myGEXFXElement.Attribute(XNamespace.Xmlns + "viz") == null)
                myGEXFXElement.Add(new XAttribute(XNamespace.Xmlns + "viz", viz.NamespaceName));

            return new XElement(viz + "color",
                          new XAttribute("r", myIColor.Red),
                          new XAttribute("g", myIColor.Green),
                          new XAttribute("b", myIColor.Blue));

        }

        #endregion

        #region ToXML(this myIPosition, myGEXFXElement)

        public static XElement ToXML(this IPosition myIPosition, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myIPosition == null)
                throw new ArgumentNullException("myIPosition must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            if (myGEXFXElement.Attribute(XNamespace.Xmlns + "viz") == null)
                myGEXFXElement.Add(new XAttribute(XNamespace.Xmlns + "viz", viz.NamespaceName));

            return new XElement(viz + "position",
                          new XAttribute("x", myIPosition.X),
                          new XAttribute("y", myIPosition.Y),
                          new XAttribute("z", myIPosition.Z));

        }

        #endregion

        #region ToXML(this myINodeShape, myGEXFXElement)

        public static XElement ToXML(this INodeShape myINodeShape, XElement myGEXFXElement)
        {

            #region Initial checks

            if (myINodeShape == null)
                throw new ArgumentNullException("myINodeShape must not be null!");

            if (myGEXFXElement == null)
                throw new ArgumentNullException("myGEXFXElement must not be null!");

            #endregion

            if (myGEXFXElement.Attribute(XNamespace.Xmlns + "viz") == null)
                myGEXFXElement.Add(new XAttribute(XNamespace.Xmlns + "viz", viz.NamespaceName));

            return new XElement(viz + "shape", new XAttribute("value", myINodeShape.Shape));

        }

        #endregion



        #region Save(this myIGEXF, myFileName)

        /// <summary>
        /// Stores the given IGEXF graph on disk
        /// </summary>
        /// <param name="myFileName">The filename for storing the graph</param>
        public static IGEXF Save(this IGEXF myIGEXF, String myFileName)
        {

            #region Initial checks

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            if (myFileName.IsNullOrEmpty())
                throw new ArgumentNullException("myFileName must not be null!");

            #endregion

            if (!myFileName.Contains("."))
                myFileName += ".gexf";

            myIGEXF.ToXML().Save(myFileName);

            return myIGEXF;

        }

        #endregion

        #region Save(this myIGEXF, myFileName, mySaveOptions)

        /// <summary>
        /// Stores the given IGEXF graph on disk
        /// </summary>
        /// <param name="myFileName">The filename for storing the graph</param>
        /// <param name="mySaveOptions">The SaveOptions</param>
        public static IGEXF Save(this IGEXF myIGEXF, String myFileName, SaveOptions mySaveOptions)
        {

            #region Initial checks

            if (myIGEXF == null)
                throw new ArgumentNullException("myIGEXF must not be null!");

            if (myFileName.IsNullOrEmpty())
                throw new ArgumentNullException("myFileName must not be null!");

            #endregion

            if (!myFileName.Contains("."))
                myFileName += ".gexf";

            myIGEXF.ToXML().Save(myFileName, mySaveOptions);

            return myIGEXF;

        }

        #endregion


    }

}
