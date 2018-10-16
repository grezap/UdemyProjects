
<?php include("includes/header.php"); ?>


<?php 
    if (!$session->getSignedIn()) {
         var_dump($session); 
         redirectTo("login.php"); 
        //  redirectTo("login.php"); 
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
        // $user->firstname = 'user8';
        // $user->lastname = 'user8';
        // $user->username = 'user8';
        // $user->password = '1234';
        // $result = $user->saveUser();
        
        // $user = User::getUserById(6);
        // $user->deleteUser();

        // $user1 = User::getUserById(8);
        // $user1->firstname = 'user7Updated';
        // $user1->lastname = 'user7Updated';
        // $user1->username = 'user7';
        // $user1->password = '1234';
        // $user1->saveUser();

        // $photo = new Photo();
        // $photo->photo_title='photo2';
        // $photo->photo_description='photo2 Description';
        // $photo->photo_filename='photoTwo';
        // $photo->photo_type='jpg';
        // $photo->photo_size = 100;
        // $photo->save();

       // echo INCLUDES_PATH;

        // $photo = Photo::getById(2);
        // $photo->delete();


    ?>

    </div>
        <!-- /#page-wrapper -->

  <?php include("includes/footer.php"); ?>