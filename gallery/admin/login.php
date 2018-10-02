<?php require_once("includes/header.php"); ?>
<?php 
    if ($session->getSignedIn()) {
        redirectTo("../admin/index.php");
    }

    if (isset($_POST['submit'])) {
        
        $username = trim($_POST['username']);
        $password = trim($_POST['password']);
        $message = "";

        $userFound = User::verifyUser($username, $password);

        if ($userFound) {
            $message = "";
            $session->loginUser($userFound);
            redirectTo("index.php");
        }
        else {
            $message = "Your username / password is incorrect";
            
        } 
    }else {
           $username = "";
           $password = "";
           $message = "";
    }

?>

<div class="col-md-4 col-md-offset-2">
    
    <h4 class="bg-danger"><?php echo $message; ?></h4>

    <form action="" method="post" class="form-horizontal">
        
        <div class="page-header">
          <h1>Login</h1>
        </div>

        <div class="form-group">
            <label for="username">Username</label>
            <input type="text" name="username" class="form-control" value="<?php echo htmlentities($username); ?>">
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input type="password" name="password" class="form-control" value="<?php echo htmlentities($password); ?>">
        </div>
        <div class="form-group">
            <input type="submit" name="submit" value="Submit" class="btn btn-primary">
        </div>
    </form>
</div>

  <?php require_once("includes/footer.php"); ?>

