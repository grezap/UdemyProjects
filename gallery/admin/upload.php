<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
         //var_dump($session); 
         redirectTo("login.php"); 
        }

?>
<?php 
    $message = "";
    if (isset($_POST['submit'])) {
        $photo = new Photo();
        $photo->photo_title = $_POST['title'];
        $photo->photo_description = $_POST['description'];
        if ($photo->setFile($_FILES['file_upload'])) {
            $message = "Photo has been configured correctly for upload.";
            if ($photo->savePhoto()) {
                $message = "Photo has been saved successfully";
                
            }else{
                $message = "Photo has not been saved successfully";
                $message = join("<br>", $photo->customErrors);
            }
            
        }else {
            $message = "Photo has not been configured correctly for upload and save in database.";
            $message = join("<br>", $photo->customErrors);
        }
        
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
                    Upload
                    <small>Upload Admin</small>
                </h1>
                
                <div class="col-md-6">

                <h4 class="bg-danger"><?php echo $message; ?></h4>

                    <form action="upload.php" method="POST" enctype="multipart/form-data" class="form-horizontal" role="form">
                        <div class="form-group">
                            
                            <input type="text" name="title" class="form-control" placeholder="title">
                            
                        </div>    
                        <div class="form-group">
                            
                            <input type="text" name="description" class="form-control" placeholder="description">
                            
                        </div>   
                        <div class="form-group">
                            
                            <input type="file" name="file_upload" class="form-control">
                            
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10 col-sm-offset-2">
                                <input type="submit" name="submit" value="Submit" class="btn btn-primary">
                            </div>
                        </div>
                    </form>
                </div>

            </div>
        </div>
        <!-- /.row -->

</div>
<!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->

  <?php include("includes/footer.php"); ?>