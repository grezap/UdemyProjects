<?php 

use voku\helper\Paginator;

require __DIR__.'/vendor/autoload.php';

include_once('Database.php');

$tasks = '';

try{

    $paginate = new Paginator(2, 'p');

    $qry = "SELECT * FROM tasks;";
    $statement= $conn->query($qry);
    $total = $statement->rowCount();
    $paginate->set_total($total);

    $tasks = $conn->query("SELECT * FROM tasks " . $paginate->get_limit());


}catch(PDOException $ex){
    echo "An error occured " . $ex->getMessage();
}

?>