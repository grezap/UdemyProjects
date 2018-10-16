<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
         redirectTo("login.php"); 
        }

?>
<?php 

if (empty($_GET['id'])) {
        redirectTo("../comments.php");
    }

    $comment = Comment::getById($_GET['id']);

    if ($comment) {
        $res = $comment->delete();
        if ($res) {
            
            $session->showMessage("Deleted Comment Id: {$comment->comment_id} Successfully");
            redirectTo("../comments.php");
        }
        
    }else {
        $session->showMessage("Could Not Delete");
        redirectTo("../comments.php");
    }
    

?>