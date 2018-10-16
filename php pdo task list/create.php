<?php 
include_once('Database.php');

$form_errors = [];
$data = [];

if (isset($_POST['name']) && isset($_POST['description'])) {
    $name = $_POST['name'];
    $description = $_POST['description'];

    if (!$name || $name == null) {
        $form_errors['name'] = "Task name is required";
    }

    if (!$description || $description == null) {
        $form_errors['description'] = "Task description is required";
    }

    if (count($form_errors) < 1) {
        try{
            $qry = "INSERT INTO tasks(name, description, createdAt) VALUES (:name, :descr, now())";
            $statement = $conn->prepare($qry);
            $statement -> execute(array(":name"=>$name, ":descr"=>$description));
            if ($statement) {
                $data['success'] = true;
                $data['message'] = "Record Inserted";
            }
        }catch(PDOException $ex){
            echo "An error occured " . $ex->getMessage();
        }
    }else {
        $data['success'] = false;
        $data['message'] = $form_errors;
    }

    echo json_encode($data);

}
?>