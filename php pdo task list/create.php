<?php 
include_once('Database.php');
if (isset($_POST['name']) && isset($_POST['description'])) {
    $name = $_POST['name'];
    $description = $_POST['description'];

    try{
        $qry = "INSERT INTO tasks(name, description, createdAt) VALUES (:name, :descr, now())";
        $statement = $conn->prepare($qry);
        $statement -> execute(array(":name"=>$name, ":descr"=>$description));
        if ($statement) {
            echo "Record Inserted";
        }
    }catch(PDOException $ex){
        echo "An error occured " . $ex->getMessage();
    }
}
?>