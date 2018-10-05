<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
         redirectTo("login.php"); 
        }

?>
<?php 

if (empty($_GET['id'])) {
        redirectTo("../photos.php");
    }

    $photo = Photo::getById($_GET['id']);

    if ($photo) {
        $res = $photo->deletePhoto();
        if ($res) {
            
            $session->showMessage("Deleted Photo Id: {$photo->photo_id} , Name: {$photo->photo_filename} Successfully");
            redirectTo("../photos.php");
        }
        
    }else {
        $session->showMessage("Could Not Delete");
        redirectTo("../photos.php");
    }
    

?>