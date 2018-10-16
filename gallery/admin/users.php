<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
        //  var_dump($session); 
         redirectTo("login.php"); 
        }

?>
<?php
    
    $users = User::getAll();
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
                    Users
                    <small>Users Admin</small>
                </h1>
                <div class="col-md-4">
                    <a href="addUser.php" class="btn btn-primary">Add User</a>
                </div>
                <br>
                <br>

                <div class="col-md-12">
                    <div  class="col-md-8">
                        <?php  if (!empty($session->message)) { ?>

                        <div id="msg" class="alert alert-info">
                            <?php echo $session->message; ?>
                        </div>

                        <?php }?>
                    </div>



                    <!-- User Table  -->
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Photo</th>
                                <th>Author</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php foreach ($users as $user) : ?>
                            <tr>
                                <td>
                                    <?php echo $user->user_id; ?>
                                </td>
                                <td>
                                    <img class="admin-user-thumbnail" src="<?php echo $user->getUserImage(); ?>" alt="">
                                </td>
                                <td>
                                    <?php echo $user->username; ?>
                                    <div class="actionsLink">
                                        <a href="DeleteUser.php/?id=<?php echo $user->user_id; ?>">Delete</a>
                                        <a href="editUser.php?id=<?php echo $user->user_id; ?>">Edit</a>
                                        <a href="#">View</a>
                                    </div>
                                </td>
                                <td>
                                    <?php echo $user->firstname; ?>
                                </td>
                                <td>
                                    <?php echo $user->lastname; ?>
                                </td>
                            </tr>
                            <?php endforeach; ?>
                        </tbody>
                    </table>
                    <!-- End Photo Table  -->
                </div>

            </div>
        </div>
        <!-- /.row -->

    </div>
    <!-- /.container-fluid -->
</div>
<!-- /#page-wrapper -->

<?php include("includes/footer.php"); ?>