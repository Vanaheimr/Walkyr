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
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace GEXFSharp
{

    public class AttributeList : IAttributeList //, IList<Attribute>
    {

        private readonly List<IAttribute> _List;


	    public DateTime? EndDate   { get; set; }
        public DateTime? StartDate { get; set; }

        public Mode _Mode = Mode.STATIC;
        public Mode Mode
        {

            get
            {
                return _Mode;
            }

            set
            {

                _Mode = value;

                if (_Mode == Mode.STATIC)
                {
                    StartDate = null;
                    EndDate   = null;
                }

            }
        
        }

        private AttributeClass attrClass = AttributeClass.NODE;

	    public AttributeList(AttributeClass attrClass) {
		    this.attrClass = attrClass;
            Mode = Mode.STATIC;
            _List = new List<IAttribute>();
	    }


	    public AttributeClass getAttributeClass() {
		    return attrClass;
	    }

        //public IAttributeList clearEndDate() {
        //    EndDate = null;
        //    return this;
        //}


        //public IAttributeList clearStartDate() {
        //    StartDate = null;
        //    return this;
        //}

        //public Boolean hasEndDate() {
        //    return (EndDate != null);
        //}


        //public Boolean hasStartDate() {
        //    return (StartDate != null);
        //}


	    public IAttribute CreateAttribute(AttributeType type, String title) {
            return CreateAttribute(Guid.NewGuid().ToString(), type, title);
	    }


	    public IAttribute CreateAttribute(String id, AttributeType type, String title = null)
        {
//		    checkArgument(id != null, "ID cannot be null.");
//		    checkArgument(!id.trim().isEmpty(), "ID cannot be empty or blank.");
//		    checkArgument(title != null, "Title cannot be null.");
//		    checkArgument(!title.trim().isEmpty(), "Title cannot be empty or blank.");

		    Attribute rv = new Attribute(id, type, title);
		    _List.Add(rv);
		    return rv;
	    }


	    public IAttributeList AddAttribute(AttributeType type, String title) {
		    return AddAttribute(Guid.NewGuid().ToString(), type, title);
	    }


	    public IAttributeList AddAttribute(String id, AttributeType type, String title) {
		    CreateAttribute(id, type, title);
		    return this;
	    }






        #region IAttributeList Members

        public AttributeList AddAttribute(AttributeType type, string title, string id = null)
        {
            throw new NotImplementedException();
        }

        public Attribute CreateAttribute(AttributeType type, string title, string id = null)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
