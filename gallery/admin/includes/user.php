<?php

    class User{

        public $user_id;
        public $username;
        public $password;
        public $firstname;
        public $lastname;

        public static function getAllUsers(){

            return self::findThisQuery("select * from users");
        }

        public static function getUserById($userId){

            $result = self::findThisQuery("select * from users where user_id = $userId");
            
            return !empty($result)?array_shift($result):false;

        }

        private static function findThisQuery($qry){
            global $database;
            $result =  $database->query($qry);
            $object_array = array();
            while ($row = mysqli_fetch_array($result)) {
                $object_array[] = self::instantiate($row);
            }
            return $object_array;
        }

        public static function instantiate($us){

            $user = new self;
            
            foreach ($us as $attribute => $value) {

                if ($user->has_the_attribute($attribute)) {
                    $user->$attribute = $value;
                }
            }

            return $user;
        }

        private function has_the_attribute($attribute){
            $props = get_object_vars($this);
            if (array_key_exists($attribute, $props)) {
                return true;
            }
            return false;
        }

        public static function verifyUser(string $username, string $password)
        {
            global $database;
            $username = $database->escapeString($username);
            $password = $database->escapeString($password);
            $result = self::findThisQuery("select * from users where username = '{$username}' and password = '{$password}';");
            return !empty($result) ? array_shift($result) : false;
        }

    }
?>