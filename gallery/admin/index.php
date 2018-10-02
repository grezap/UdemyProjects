
<?php include("includes/header.php"); ?>


<?php 
    if (!$session->getSignedIn()) {
         var_dump($session); 
         redirectTo("login.php"); 
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
            Dashboard
            <small>WebSite Dashboard</small>
        </h1>
        <ol class="breadcrumb">
            <li>
                <i class="fa fa-dashboard"></i>  <a href="index.php">Dashboard</a>
            </li>
            <li class="active">
                <i class="fa fa-file"></i> Blank Page
            </li>
        </ol>
    </div>
</div>
<!-- /.row -->

</div>
<!-- /.container-fluid -->



    <?php 
        // $user = new User();
        $result = User::getAllUsers();
        // while ($row = mysqli_fetch_array($result)) {
        //     echo $row['username']."<br>";
        // }

        // $us = User::getUserById(1);
        // echo $us['username']."<br>";

        // $user = User::instantiate($us);
        // echo $user->userId;
        foreach ($result as $user) {
            echo $user->username."<br>";
        }
        echo "<br>";
        $user = User::getUserById(1);
        echo $user->username;
    ?>

    </div>
        <!-- /#page-wrapper -->

  <?php include("includes/footer.php"); ?>