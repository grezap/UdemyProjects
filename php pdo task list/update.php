<?php 
include_once('Database.php');


if (isset($_POST['id'])) {

    $column = trim($_POST['column']);
    $theData = $_POST['theData'];
    $id = $_POST['id'];

    try{
        $qry = "UPDATE tasks set {$column} = :placeholder where id = :id";
        $statement = $conn->prepare($qry);
        $statement -> execute(array(":placeholder"=>$theData, ":id"=>$id));
        if ($statement->rowCount() === 1) {
            echo "Task {$column} Updated Succesfully";
        }else{
            echo "No Changes Have been Applied";
        }
    }catch(PDOException $ex){
        echo "An error occured " . $ex->getMessage();
    }

}

?>

