<?php 

    require_once("new_config.php");

    class Database{

        private $connection;

        function __construct()
        {
            $this->openDbConnection();
        }

        public function openDbConnection(){
            // $this->connection = mysqli_connect(DB_HOST,DB_USER,DB_PASSWORD,DB_NAME);

            $this->connection = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAME);

            if ($this->connection->connect_errno) {
                die("Database connection failed ". $this->connection->connect_errno);
            }
        }

        public function query($qry){
            $result = $this->connection->query($qry);
            $this->confirmQuery($result);
            return $result;
        }

        private function confirmQuery($result){
            if (!$result) {
                die("Query Failed. ".$this->connection->error);
            }
        }

        public function escapeString($qry){
            $escapedstring = $this->connection->real_escape_string($qry);
            return $escapedstring;
        }

        public function getInsertId() {
            return $this->connection->insert_id;
        }

    }

    $database = new Database();

?>