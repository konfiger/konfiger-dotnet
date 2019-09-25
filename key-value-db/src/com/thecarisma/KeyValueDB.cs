using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.thecarisma
{
    public class KeyValueDB : IEnumerable<KeyValueObject>
    {

        /**
         * 
         */
        private char delimeter ;
    
        /**
         * 
         */
        private char seperator ;
    
        /**
         * 
         */
        private bool dbChanged = true;

        /**
         *
         */
        private bool isCaseSensitive = true;
    
        /**
         * 
         */
        private string stringValue = "" ;
    
        /**
         * 
         */
        private List<KeyValueObject> keyValueObjects = new List<KeyValueObject>();
    
        /**
         * 
         */
        public KeyValueDB() 
        {
            Parser("", true, '=', '\n', false);
        }

        /**
         * 
         * @param keyValueDB 
         */
        public KeyValueDB(string keyValueDB) 
        {
            Parser(keyValueDB, true, '=', '\n', false);
        }
    
        /**
         * 
         * @param keyValueDB
         * @param caseSensitive 
         */
        public KeyValueDB(string keyValueDB, bool caseSensitive) 
        {
            Parser(keyValueDB, caseSensitive, '=', '\n', false);
        }
    
        /**
         * 
         * @param keyValueDB
         * @param caseSensitive
         * @param delimeter 
         */
        public KeyValueDB(string keyValueDB, bool caseSensitive, char delimeter)
        {
            Parser(keyValueDB, caseSensitive, delimeter, '\n', false);
        }
    
        /**
         * 
         * @param keyValueDB
         * @param caseSensitive
         * @param delimeter
         * @param seperator 
         */
        public KeyValueDB(string keyValueDB, bool caseSensitive, char delimeter, char seperator)
        {
            Parser(keyValueDB, caseSensitive, delimeter, seperator, false);
        }
    
        /**
         * 
         * @param keyValueDB
         * @param caseSensitive
         * @param delimeter
         * @param seperator
         * @param errTolerance 
         */
        public KeyValueDB(string keyValueDB, bool caseSensitive, char delimeter, char seperator, bool errTolerance)
        {
            Parser(keyValueDB, caseSensitive, delimeter, seperator, errTolerance);
        }
    
        /**
         * 
         * @param index
         * @return 
         */
        public KeyValueObject GetKeyValueObject(int index) 
        {
            return keyValueObjects[index];
        }
    
        /**
         * 
         * @param key
         * @return 
         */
        public KeyValueObject GetKeyValueObject(string key) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects) 
            {
                if (keyValueObject.getKey().Contains(key)) 
                {
                    return keyValueObject ;
                }
            }
            return new KeyValueObject("","");
        }

        /**
         * 
         * @param key
         * @return 
         */
        public KeyValueObject GetLikeKeyValueObject(string key)
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects)
            {
                if (keyValueObject.getKey().Equals(key))
                {
                    return keyValueObject;
                }
            }
            return new KeyValueObject("", "");
        }
    
        /**
         * 
         * @param index
         * @return 
         */
        public string Get(int index) 
        {
            return keyValueObjects[index].getValue();
        }
    
        /**
         * 
         * @param key
         * @return 
         */
        public string Get(string key) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects) 
            {
                if (keyValueObject.getKey().Equals(key)) 
                {
                    return keyValueObject.getValue() ;
                }
            }
            return "";
        }

        /**
         * 
         * @param key
         * @return 
         */
        public string GetLike(string key)
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects)
            {
                if (keyValueObject.getKey().Contains(key))
                {
                    return keyValueObject.getValue();
                }
            }
            return "";
        }
    
        /**
         * 
         * @param key
         * @param defaultKeyValueObject
         * @return 
         */
        public KeyValueObject GetKeyValueObject(string key, KeyValueObject defaultKeyValueObject) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects) 
            {
                if (keyValueObject.getKey().Equals(key)) 
                {
                    return keyValueObject;
                }
            }
            return defaultKeyValueObject;
        }

        /**
         * 
         * @param key
         * @param defaultKeyValueObject
         * @return 
         */
        public KeyValueObject GetLikeKeyValueObject(string key, KeyValueObject defaultKeyValueObject)
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects)
            {
                if (keyValueObject.getKey().Contains(key))
                {
                    return keyValueObject;
                }
            }
            return defaultKeyValueObject;
        }
    
        /**
         * 
         * @param key
         * @param defaultKeyValueObject
         * @return 
         */
        public string Get(string key, KeyValueObject defaultKeyValueObject) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects) 
            {
                if (keyValueObject.getKey().Equals(key)) 
                {
                    return keyValueObject.getValue() ;
                }
            }
            return defaultKeyValueObject.getValue();
        }

        /**
         * 
         * @param key
         * @param defaultKeyValueObject
         * @return 
         */
        public string GetLike(string key, KeyValueObject defaultKeyValueObject)
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects)
            {
                if (keyValueObject.getKey().Contains(key))
                {
                    return keyValueObject.getValue();
                }
            }
            return defaultKeyValueObject.getValue();
        }
    
        /**
         * 
         * @param key
         * @param defaultValue
         * @return 
         */
        public string Get(string key, string defaultValue) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject_ in keyValueObjects) 
            {
                if (keyValueObject_.getKey().Equals(key)) 
                {
                    return keyValueObject_.getValue() ;
                }
            }
            return defaultValue;
        }

        /**
         * 
         * @param key
         * @param defaultValue
         * @return 
         */
        public string GetLike(string key, string defaultValue)
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject_ in keyValueObjects)
            {
                if (keyValueObject_.getKey().Contains(key))
                {
                    return keyValueObject_.getValue();
                }
            }
            return defaultValue;
        }
    
        /**
         * 
         * @param index
         * @param value 
         */
        public void Set(int index, string value) 
        {
            dbChanged = true ;
            keyValueObjects[index].setValue(value);
        }
    
        /**
         * 
         * @param key
         * @param value 
         */
        public void Set(string key, string value) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            foreach (KeyValueObject keyValueObject in keyValueObjects) 
            {
                if (keyValueObject.getKey().Equals(key)) 
                {
                    keyValueObject.setValue(value);
                    dbChanged = true ;
                    return;
                }
            }
            Add(key, value);
        }
    
        /**
         * 
         * @param index
         * @param keyValueObject 
         */
        public void SetKeyValueObject(int index, KeyValueObject keyValueObject) 
        {
            dbChanged = true ;
            keyValueObjects[index] = keyValueObject;
        }
    
        /**
         * 
         * @param key
         * @param keyValueObject 
         */
        public void SetKeyValueObject(string key, KeyValueObject keyValueObject) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            for (int i = 0; i <= keyValueObjects.Count; i++) 
            {
                if (keyValueObjects[i].getKey().Equals(key)) 
                {
                    keyValueObjects[i] = keyValueObject;
                    dbChanged = true ;
                    return;
                }
            }
            Add(keyValueObject);
        }
    
        /**
         * 
         * @param keyValueObject 
         */
        public void Add(KeyValueObject keyValueObject) 
        {
            String key = keyValueObject.getKey();
            if (!isCaseSensitive) key = key.ToLower();
            if (!Get(key).Equals(""))
            {
                SetKeyValueObject(key, keyValueObject);
                return;
            }
            keyValueObjects.Add(keyValueObject);
            dbChanged = true ;
        }
    
        /**
         * 
         * @param key
         * @param value 
         */
        public void Add(string key, string value) 
        {
            if (!isCaseSensitive) key = key.ToLower();
            if (!Get(key).Equals("")) 
            {
                Set(key, value);
                return;
            }
            keyValueObjects.Add(new KeyValueObject(key, value));
            dbChanged = true ;
        }

        public KeyValueObject Remove(int index)
        {
            KeyValueObject keyValueObject = keyValueObjects[index];
            if (keyValueObjects.Remove(keyValueObject))
            {
                return keyValueObject;
            }
            dbChanged = true;
            return new KeyValueObject("", "");
        }

        public KeyValueObject Remove(String key)
        {
            KeyValueObject keyValueObject = new KeyValueObject("", "");
            if (!isCaseSensitive) key = key.ToLower();
            for (int i = 0; i <= keyValueObjects.Count; i++)
            {
                if (keyValueObjects[i].getKey().Equals(key))
                {
                    keyValueObject = keyValueObjects[i];
                    if (keyValueObjects.Remove(keyValueObject))
                    {
                        dbChanged = true;
                        return keyValueObject;
                    }
                    break;
                }
            }
            return keyValueObject;
        }
    
        /**
         * 
         * @param keyValueDB
         * @param caseSensitive
         * @param delimeter
         * @param seperator
         * @param errTolerance 
         */
        private void Parser(string keyValueDB, bool caseSensitive, char delimeter, char seperator, bool errTolerance) 
        {
            this.delimeter = delimeter;
            this.seperator = seperator;
            this.isCaseSensitive = caseSensitive;
            char[] characters = keyValueDB.Replace("\r", "").ToCharArray();
            string key = "", value = "" ;
            bool parseKey = true;
            int line = 1, column = 0;
            for (int i = 0; i <= characters.Length ; i++ ) 
            {
                if (i == characters.Length)
                {
                    if (!key.Equals("")) 
                    {
                        if (key.Equals("") && value.Equals("")) continue;
                        if (parseKey && !errTolerance) throw new Exception("Invalid entry detected near Line " + line + ":" + column);
                        keyValueObjects.Add(new KeyValueObject(key, value));
                    }
                    break;
                }
                char character = characters[i];
                column++;
                if (character == '\n') 
                {
                    line++;
                    column = 0 ;
                }
                if (character == seperator) 
                {
                    if (key.Equals("") && value.Equals("")) continue;
                    if (parseKey && !errTolerance) throw new Exception("Invalid entry detected near Line " + line + ":" + column);
                    keyValueObjects.Add(new KeyValueObject(key, value));
                    parseKey = true ;
                    key = "";
                    value = "";
                    continue;
                }
                if (character == delimeter) 
                {
                    if (!value.Equals("") && !errTolerance)  throw new Exception("The input is imporperly sepreated near Line " + line + ":" + column+". Check the seperator");
                    parseKey = false ;
                    continue;
                }
                if (parseKey) 
                {
                    if (caseSensitive) 
                    {
                        key += character; 
                    }
                    else 
                    {
                        key += ("" + character).ToLower();
                    }
                } else {
                    value += character ;
                }
            }
        }
    

        public override string ToString() 
        {
            if (dbChanged) 
            {
                stringValue = "" ;
                for (int i = 0; i < keyValueObjects.Count; i++) 
                {
                    stringValue += keyValueObjects[i].getKey() + delimeter + keyValueObjects[i].getValue() ;
                    if (i != (keyValueObjects.Count - 1)) stringValue += seperator;
                }
                dbChanged = false ;
            }
            return stringValue;
        }


        public IEnumerator<KeyValueObject> GetEnumerator()
        {
            return keyValueObjects.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
}
