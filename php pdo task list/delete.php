<?php 
include_once('Database.php');
if (isset($_POST['id'])) {
    $id = $_POST['id'];

    try{
        $qry = "delete from tasks where id = :id";
        $statement = $conn->prepare($qry);
        $statement -> execute(array(":id"=>$id));
        if ($statement) {
            echo "Record Deleted";
        }
    }catch(PDOException $ex){
        echo "An error occured " . $ex->getMessage();
    }
}
?>