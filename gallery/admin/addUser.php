<?php include("includes/header.php"); ?>
<?php 
if (!$session->getSignedIn()) {
        //  var_dump($session); 
    redirectTo("login.php");
}

?>
<?php 

if (isset($_POST['create'])) {

    if (empty($_POST['username']) || empty($_POST['password'])) {
        $session->showMessage("Username or Password cannot be empty");
       
    }else{
        $user = new User();

        $user->username = $_POST['username'];
        $user->password = $_POST['password'];
        $user->firstname = $_POST['firstname'];
        $user->lastname = $_POST['lastname'];
        
        if (isset($_FILES['file_upload'])) {
            $user->setUserImage($_FILES['file_upload']);
        }
    
        $user->saveUser();
        $session->showMessage("New User {$_POST['username']} was saved succcesfully.");
        
    }
    redirectTo("users.php");

}

?>
<!-- Navigation -->
<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <!-- Brand and toggle get grouped for better mobile display -->
    <?php include("includes/top_nav.php") ?>

    <!-- Sidebar Menu Items - These collapse to the responsive navigation menu on small screens -->
    <?php include("includes/side_nav.php") ?>
    <!-- /.navbar-collapse -->
</nav>

<div id="page-wrapper">
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Add User
                </h1>
                <form action="" method="POST" enctype="multipart/form-data">

                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="username" class="col-sm-2">Username</label>
                            <input type="text" name="username" class="form-control" placeholder="Username">

                        </div>
                        <div class="form-group">
                            <label for="password" class="col-sm-2">Password</label>
                            <input type="password" name="password" class="form-control" placeholder="Password">
                        </div>
                        <div class="form-group">
                            <label for="firstname" class="col-sm-2">Firstname</label>
                            <input type="text" name="firstname" class="form-control" placeholder="Firstname">
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2">Lastname</label>
                            <input type="text" name="lastname" class="form-control" placeholder="Lastname">
                        </div>
                        <div class="form-group">
                            <label for="file_upload" class="col-sm-2">Upload Image</label>
                            <input type="file" name="file_upload" class="form-control">
                        </div>
                        <div class="form-group">
                            <input type="submit" name="create" value="Create" class="btn btn-primary pull-right">
                        </div>
                    </div>

                </form>
            </div>
        </div>
        <!-- /.row -->

    </div>
    <!-- /.container-fluid -->
</div>
<!-- /#page-wrapper -->

<?php include("includes/footer.php"); ?>