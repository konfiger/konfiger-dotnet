using System;

namespace io.github.thecarisma
{
    /*
     
     */
    public class KeyValueObject
    {

        /* 
            
	    */
        private String key;

        /*
         
         */
        private String value;

        /*
         
         
         
         
         **Parameters**:	
			key : string
				The key to identify the object with
			value : string
				The actual value of the object 
         */
        public KeyValueObject(string key, string value)
        {
            this.key = key.Trim();
            this.value = value;
        }

        /**
          
         **return**:
		    The key id of the Object as String
         */
        public String getKey() {
            return key;
        }
    
        /**
          
         **return**:
		    The actual value of the Object as String
         */
        public String getValue() {
            return value;
        }

        /**
         
         **Parameters**:	
            key : string
                The key to identify the object with
         */
        public void setKey(String key) {
            this.key = key.Trim();;
        }

        /**
         
         **Parameters**:	
            value : string
				The actual value of the object 
         */
        public void setValue(String value) {
            this.value = value;
        }
    
        /**
         * 
         
          
         **return**:
		    The String representation of the KeyValueObject
         */
        public override string ToString() {
            return "com.azeezadewale.KeyValueObject@" + this.GetHashCode() + ":Key=" + key + ",Value=" + value;
        }

    }
}
