<?php

// define("DSN", "mysql:host=192.168.203.6;dbname=tasklist");
define("DSN", "mysql:host=localhost;dbname=tasklist");
// define("USERNAME", "usr");
define("USERNAME", "root");
// define("PASSWORD", "tzimakos");
define("PASSWORD", "tzimakos");


$options = array(PDO::ATTR_PERSISTENT => true);

try{
    $conn = new PDO(DSN, USERNAME, PASSWORD, $options);

    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    //echo "connection successful";

}catch (PDOException $ex){
    echo "A database error occurred ".$ex->getMessage();
}
