<?php require_once("includes/header.php"); ?>
<?php 
    $session->logoutUser();
    redirectTo("login.php");
?>