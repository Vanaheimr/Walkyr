using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEXFSharp
{

    public abstract class ASliceableDatum<T> : ASlicable<T>//, ISlicableDatum<T>
    {

	    private IAttributeValueList attributes = null;

        public ASliceableDatum()
        {
		    attributes = new AttributeValueList();
	    }

	    public IAttributeValueList getAttributeValues() {
		    return attributes;
	    }

    }

}
