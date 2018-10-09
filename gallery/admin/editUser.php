<?php include("includes/header.php"); ?>
<?php 
if (!$session->getSignedIn()) {
        //  var_dump($session); 
    redirectTo("login.php");
}

?>
<?php 

if (!isset($_GET['id'])) {
    $session->showMessage("User Id was not set.");
    redirectTo('users.php');
}

$user = User::getById($_GET['id']);

if (isset($_POST['update'])) {

    if (empty($_POST['username']) || empty($_POST['password'])) {
        $session->showMessage("Username or Password cannot be empty");
    }
    elseif ($user && !empty($_POST['username']) && !empty($_POST['password'])) {
        $user->username = $_POST['username'];
        $user->password = $_POST['password'];
        $user->firstname = $_POST['firstname'];
        $user->lastname = $_POST['lastname'];
        if (isset($_FILES['file_upload'])) {
            $user->setUserImage($_FILES['file_upload']);
        }
        $user->saveUser();
        $session->showMessage("User {$user->user_id} has been updated successfully.");
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
                    Edit User
                </h1>
                <div class="col-md-4">
                    <div class="form-group">
                        <img name="userimage" src="<?php echo $user->getUserImage(); ?>" alt="" class="thumbnail">
                    </div>
                </div>
                <form action="" method="POST" enctype="multipart/form-data">

                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="username" class="col-sm-2">Username</label>
                            <input type="text" name="username" class="form-control" value="<?php echo $user->username; ?>">

                        </div>
                        <div class="form-group">
                            <label for="password" class="col-sm-2">Password</label>
                            <input type="text" name="password" class="form-control" value="<?php echo $user->password; ?>">
                        </div>
                        <div class="form-group">
                            <label for="firstname" class="col-sm-2">Firstname</label>
                            <input type="text" name="firstname" class="form-control" value="<?php echo $user->firstname; ?>">
                        </div>
                        <div class="form-group">
                            <label for="lastname" class="col-sm-2">Lastname</label>
                            <input type="text" name="lastname" class="form-control" value="<?php echo $user->lastname; ?>">
                        </div>
                        <div class="form-group">
                            <input type="file" name="file_upload" >
                        </div>
                        <div class="form-group">
                            <input type="submit" name="update" value="Update" class="btn btn-primary pull-right">
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