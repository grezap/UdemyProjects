<?php

    class User extends dbObject {

        protected static $dbTable = 'user';
        public $idProp;
        protected static $dbTableFields = array('username','password','firstname','lastname');        
        public $user_id;
        public $username;
        public $password;
        public $firstname;
        public $lastname;

        public static function verifyUser(string $username, string $password){
            global $database;
            $username = $database->escapeString($username);
            $password = $database->escapeString($password);
            $result = self::findByQuery("select * from ".self::$dbTable." where username = '{$username}' and password = '{$password}';");
            return !empty($result) ? array_shift($result) : false;
        }

    }
?>