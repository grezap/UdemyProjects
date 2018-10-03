<?php 
    class DbObject
    {

        public $idProp="";

        function __construct()
        {
            $this->idProp = static::$dbTable . "_id";
        }

        public static function getAll(){

            return static::findByQuery("SELECT * FROM ".static::$dbTable." ;");
        }

        public static function getById($id){

            $result = static::findByQuery("SELECT * FROM ".static::$dbTable." WHERE ".static::$dbTable."_id = $id;");
            
            return !empty($result)?array_shift($result):false;

        }

        private static function findByQuery($qry){
            global $database;
            $result =  $database->query($qry);
            $object_array = array();
            while ($row = mysqli_fetch_array($result)) {
                $object_array[] = static::instantiate($row);
            }
            return $object_array;
        }

        public static function instantiate($obj){

            $callingClass = get_called_class();
            $newObj = new $callingClass;
            
            foreach ($obj as $attribute => $value) {

                if ($newObj->has_the_attribute($attribute)) {
                    $newObj->$attribute = $value;
                }
            }

            return $newObj;
        }

        private function has_the_attribute($attribute){
            $props = get_object_vars($this);
            if (array_key_exists($attribute, $props)) {
                return true;
            }
            return false;
        }

        protected function properties(){

            $properties = array();
            foreach (static::$dbTableFields as $dbField) {
                if (property_exists($this, $dbField)) {
                    $properties[$dbField] = $this->$dbField;
                }
            }
            
            return $properties;
        }

        protected function cleanProperties(){
            global $database;

            $cleanProps = array();

            foreach ($this->properties() as $prop => $propValue) {
                $cleanProps[$prop] = $database->escapeString($propValue);
            }
            return $cleanProps;
        }


        public function save(){
            // $tst = $this->idProp;
            return isset($this->{$this->idProp}) ? $this->update() : $this->create();
        }

        public function create(){
            global $database;

            $properties = $this->cleanProperties();

            $qry = "INSERT INTO ".static::$dbTable." (".implode(",", array_keys($properties)).") ";
            $qry .= "VALUES ('".implode("','", array_values($properties))."');";

            if ($database->query($qry)) {
                $this->{$this->idProp} = $database->getInsertIdMySql();
                return true;
            }else {
                return false;
            }
            
        }

        public function update(){
            global $database;
            $properties = $this->cleanProperties();
            $properties_pairs = array();
            foreach ($properties as $key => $value) {
                $properties_pairs[]="{$key}='{$value}'";
            }
            //$qry = "UPDATE ".self::$dbTable." set username = '{$database->escapeString($this->username)}', password = '{$database->escapeString($this->password)}', ";
            //$qry .= "firstname = '{$database->escapeString($this->firstname)}', lastname = '{$database->escapeString($this->lastname)}' where user_id = {$this->user_id}; ";
            $qry = "UPDATE ".static::$dbTable." SET ";
            $qry .= implode(", ", $properties_pairs);
            $qry .= " WHERE ".static::$dbTable."_id = ".$database->escapeString($this->{$this->idProp});
            $database->query($qry);
            $db = $database->connection;
            return mysqli_affected_rows($database->connection);
        }

        public function delete(){
            global $database; 
            $qry = "DELETE FROM ".static::$dbTable." where ".static::$dbTable."_id = {$database->escapeString($this->{$this->idProp})}";
            $database->query($qry);
            $res = mysqli_affected_rows($database->connection);
            return $res > 0 ? true : false;
        }

    }
    
?>