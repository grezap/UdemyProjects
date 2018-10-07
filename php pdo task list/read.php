<?php 
include_once('Database.php');

try{
    $qry = "SELECT * FROM tasks;";
    $statement= $conn->query($qry);
    while ($task = $statement->fetch(PDO::FETCH_OBJ)) {
        $create_date = strftime("%b %d, %Y", strtotime($task->createdAt));
        $output = "<tr>
                        <td><div>$task->name</div></td>
                        <td> <div> $task->description</div> </td>
                        <td> <div>$task->status</div> </td>
                        <td>$create_date</td>
                        <td style=\"width: 5%;\"><button><i class=\"btn-danger fa fa-times\"></i></button>
                        </td>
                    </tr>";
        echo $output;
    }
}catch(PDOException $ex){
    echo "An error occured " . $ex->getMessage();
}

?>