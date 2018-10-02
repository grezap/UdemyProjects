<?php 
    class Session{

        private $signedIn = false;
        public $userId;
        public $username;
        public $message;

        function __construct()
        {
            session_start();
            $this->checkLogin();
            $this->checkMessage();
        }

        /**
         * check if the session user id is set
         * if it is set then set user id and signed in variables
         * else we will unset user id 
         */
        private function checkLogin(){
            if (isset($_SESSION['user_id'])) {
                $this->userId = $_SESSION['user_id'];
                $this->username = $_SESSION['username'];
                $this->signedIn = true;
            }
            else {
                unset($this->userId);
                $this->signedIn = false;
            }
        }

        /**
         * return the value for signed in or not
         */
        public function getSignedIn() : bool {
            return $this->signedIn;
        }

        public function loginUser(User $user) : bool {
            if ($user) {
                $this->userId = $_SESSION['user_id'] = $user->user_id;
                $this->username = $_SESSION['username'] = $user->username;
                $this->signedIn = true;
                return true;
            }
            return false;
        }

        public function logoutUser(){
            unset($_SESSION['user_id']);
            unset($_SESSION['username']);
            unset($this->userId);
            unset($this->username);
            $this->signedIn = false;
        }
        
        public function showMessage($msg=""){
            if (!empty($msg)) {
                $_SESSION['message'] = $msg;
            }else {
                return $this->message;
            }
        }

        private function checkMessage(){
            if (isset($_SESSION['message'])) {
                $this->message = $_SESSION['message'];
                unset($_SESSION['message']);
            }else {
                $this->message = "";
            }
        }


    }

    $session = new Session();

?>