<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
        //  var_dump($session); 
         redirectTo("login.php"); 
        }

?>
<?php
    $photos = Photo::getAll();
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
                    Photos
                    <small>Photos Admin</small>
                </h1>

                <div class="col-md-12">
                <!-- Photo Table  -->
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Photo</th>
                                <th>Id</th>
                                <th>Filename</th>
                                <th>Title</th>
                                <th>Description</th>
                                <th>Size</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php foreach ($photos as $photo) : ?> 
                                <tr>
                                    <td>
                                        <img src="<?php echo $photo->picturePath(); ?>" alt="">
                                        <div class="pctlnk">
                                            <a href="DeletePhoto.php/?id=<?php echo $photo->photo_id; ?>">Delete</a>
                                            <a href="#">Edit</a>
                                            <a href="#">View</a>
                                        </div>
                                    </td>
                                    <td><?php echo $photo->photo_id; ?></td>
                                    <td><?php echo $photo->photo_filename; ?></td>
                                    <td><?php echo $photo->photo_title; ?></td>
                                    <td><?php echo $photo->photo_description; ?></td>
                                    <td><?php echo $photo->photo_size; ?></td>
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