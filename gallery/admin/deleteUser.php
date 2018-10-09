<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
         redirectTo("login.php"); 
        }

?>
<?php 

if (empty($_GET['id'])) {
        redirectTo("../users.php");
    }

    $user = User::getById($_GET['id']);

    if ($user) {
        $res = $user->deleteUser();
        if ($res) {
            
            $session->showMessage("Deleted User Id: {$user->user_id} , UserName: {$user->username} Successfully");
            redirectTo("../users.php");
        }
        
    }else {
        $session->showMessage("Could Not Delete");
        redirectTo("../users.php");
    }
    

?>