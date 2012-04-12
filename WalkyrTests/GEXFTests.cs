using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEXFSharp;

namespace de.ahzf.WalkyrTests
{

    public class GEXFTests
    {


        public void Run()
        {

            var _DataGraph = DataGraph().Save("DataGraph");
            var _DataGraphXML = _DataGraph.ToXML();

            var _Nikolaus = DasHausDesNikolaus().Save("Nikolaus");
            var _NikolausXML = _Nikolaus.ToXML();

            var _RandomGrowingGraph = RandomGrowingGraph(1500).Save("RandomGrowingGraph");
            var _RandomGrowingGraphXML = _Nikolaus.ToXML();

            //var _XmlReaderSettings = new XmlReaderSettings() { ValidationType = ValidationType.Schema };
            //_XmlReaderSettings.Schemas.Add("http://www.gexf.net/1.1draft",     "http://www.gexf.net/1.1draft/gexf.xsd");
            //_XmlReaderSettings.Schemas.Add("http://www.gexf.net/1.1draft/viz", "http://www.gexf.net/1.1draft/viz.xsd");

            //var _XmlReader = XmlReader.Create("Nikolaus.gexf", _XmlReaderSettings);
            //while (_XmlReader.Read())
            //{ }

        }


        #region DataGraph

        public GEXF DataGraph()
        {

            var _GEXF = new GEXF();

            _GEXF.Metadata
                 .SetCreator("Gephi.org")
                 .SetDescription("A Web network");

            var _AttributeList = new AttributeList(AttributeClass.NODE);
            
//            _GEXF.Graph.AttributeLists.Add(_AttributeList);
            //Attribute attUrl      = _AttributeList.CreateAttribute("0", AttributeType.STRING,  "url");
            //Attribute attIndegree = _AttributeList.CreateAttribute("1", AttributeType.FLOAT,   "indegree");
            //Attribute attFrog     = _AttributeList.CreateAttribute("2", AttributeType.BOOLEAN, "frog")
            //    .setDefaultValue("true");

            var gephi = _GEXF.Graph.AddNode("0");
            gephi
                .SetLabel("Gephi");
                //.getAttributeValues()
                //    .addValue(attUrl, "http://gephi.org")
                //    .addValue(attIndegree, "1");

            var webatlas = _GEXF.Graph.AddNode("1");
            webatlas
                .SetLabel("Webatlas");
                //.getAttributeValues()
                //    .addValue(attUrl, "http://webatlas.fr")
                //    .addValue(attIndegree, "2");

            var rtgi = _GEXF.Graph.AddNode("2");
            rtgi
                .SetLabel("RTGI");
                //.getAttributeValues()
                //    .addValue(attUrl, "http://rtgi.fr")
                //    .addValue(attIndegree, "1");

            var blab = _GEXF.Graph.AddNode("3");
            blab
                .SetLabel("BarabasiLab");
                //.getAttributeValues()
                //    .addValue(attUrl, "http://barabasilab.com")
                //    .addValue(attIndegree, "1")
                //    .addValue(attFrog, "false");

            gephi.   ConnectTo("0", webatlas);
            gephi.   ConnectTo("1", rtgi);
            webatlas.ConnectTo("2", gephi);
            rtgi.    ConnectTo("3", webatlas);
            gephi.   ConnectTo("4", blab);

            return _GEXF;

        }

        #endregion

        #region DasHausDesNikolaus()

        public GEXF DasHausDesNikolaus()
        {

            var _GEXF  = new GEXF();
            var _Graph = _GEXF.Graph;
            _GEXF.Metadata.AddKeyword("Nikolaus").
                               AddKeyword("Haus").
                               SetCreator("ahzf").
                               SetDescription("Das Haus des Nikolaus");

            var _Node1 = _Graph.AddNode("1").SetLabel("one!").SetColor(Colors.BLUE);
            var _Node2 = _Graph.AddNode("2").SetLabel("two!").SetColor(255, 255, 0).SetSize(10.93854f);
            var _Node3 = _Graph.AddNode("3").SetLabel("three!").SetColor(Colors.RED).SetShape(new NodeShape(NodeShapes.DIAMOND));
            var _Node4 = _Graph.AddNode("4").SetLabel("four!").SetColor(Colors.GREEN);
            var _Node5 = _Graph.AddNode("5").SetLabel("five!").SetShape(NodeShapes.TRIANGLE).SetSize(20);

            _Node1.ConnectTo("Edge1-4", _Node4);
            _Node4.ConnectTo("Edge4-3", _Node3);
            _Node3.ConnectTo("Edge3-5", _Node5);
            _Node5.ConnectTo("Edge5-4", _Node4);
            _Node4.ConnectTo("Edge4-2", _Node2);
            _Node2.ConnectTo("Edge2-1", _Node1);
            _Node1.ConnectTo("Edge1-3", _Node3);
            _Node3.ConnectTo("Edge3-2", _Node2);

            return _GEXF;

        }

        #endregion

        #region RandomGrowingGraph(myNumberOfNodes, myNumberOfAdjecencies = 1)

        public GEXF RandomGrowingGraph(UInt32 myNumberOfNodes, UInt32 myNumberOfAdjecencies = 1)
        {

            if (myNumberOfNodes > Int32.MaxValue)
                throw new ArgumentException("myNumberOfNodes must be smaller than " + Int32.MaxValue + "!");

            var _GEXF           = new GEXF();
            var _Graph          = _GEXF.Graph.SetDefaultEdgeType(EdgeType.UNDIRECTED);
            var _Random         = new Random();
            var _NumberOfNodes  = (Int32) myNumberOfNodes;
            var _Neighbors      = new List<Int32>();

            _GEXF.Metadata
                 .SetCreator("ahzf")
                 .SetDescription("A random growing graph");

            _Graph.AddNode("0").SetSize(15);

            for (var i = 1; i < _NumberOfNodes; i++)
            {
                
                var _NewNode = _Graph.AddNode(i).SetSize(20);

                switch (i % 3)
                {
                    case 0: _NewNode.SetColor(Colors.RED);   break;
                    case 1: _NewNode.SetColor(Colors.GREEN); break;
                    case 2: _NewNode.SetColor(Colors.BLUE);  break;
                }

                while (_Neighbors.Count < Math.Min(myNumberOfAdjecencies, i))
                {
                    
                    var _NeighborId = _Random.Next(i);
                    
                    if (_NeighborId != i && !_Neighbors.Contains(_NeighborId))
                        _Neighbors.Add(_NeighborId);

                }

                foreach (var _NeighborId in _Neighbors)
                    _NewNode.ConnectTo(_Graph.FindNode(_NeighborId.ToString()));

                _Neighbors.Clear();

            }

            return _GEXF;

        }

        #endregion

    }

}
