<?php include("includes/header.php"); ?>
<?php 
if (!$session->getSignedIn()) {
        //  var_dump($session); 
    redirectTo("login.php");
}

?>
<?php 
if (empty($_GET['id'])) {
    $session->showMessage("Id did not exist for the photo edit.");
    redirectTo("photos.php");
}

$photo = Photo::getById($_GET['id']);

if (isset($_POST['update'])) {
    if (!$photo) {
        $session->showMessage("Photo with Id {$_GET['id']} does not exist");
        redirectTo("photos.php");
    }
    $photo->photo_title = $_POST['title'];
    $photo->photo_caption = $_POST['caption'];
    $photo->photo_description = $_POST['description'];
    $photo->photo_alternatetext = $_POST['alternatetext'];
    $photo->save();
    $session->showMessage("Photo with Id {$_GET['id']} updated succcesfully.");
    redirectTo("photos.php");
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
                    Edit Photo
                </h1>
                <form action="" method="POST">

                    <div class="col-md-8">
                        <div class="form-group">
                            <label for="title" class="col-sm-2">Title</label>
                            <input type="text" name="title" class="form-control" value="<?php echo $photo->photo_title; ?>">

                        </div>
                        <div class="form-group">
                            <a class="thumbnail" href=""><img src="<?php echo $photo->picturePath(); ?>" alt=""></a>
                        </div>
                        <div class="form-group">
                            <label for="description" class="col-sm-2">Description</label>
                            <input type="text" name="description" class="form-control" value="<?php echo $photo->photo_description; ?>">
                        </div>
                        <div class="form-group">
                            <label for="caption" class="col-sm-2">Caption</label>
                            <input type="text" name="caption" class="form-control" value="<?php echo $photo->photo_caption; ?>">
                        </div>
                        <div class="form-group">
                            <label for="alternatetext" class="col-sm-2">Alternate Text</label>
                            <textarea name="alternatetext" cols="60" rows="10"><?php echo $photo->photo_alternatetext; ?></textarea>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="photo-info-box">
                            <div class="info-box-header">
                                <h4>Save <span id="toggle" class="glyphicon glyphicon-menu-up pull-right"></span></h4>
                            </div>
                            <div class="inside">
                                <div class="box-inner">
                                    <p class="text">
                                        <span class="glyphicon glyphicon-calendar"></span> Uploaded on: April 22, 2030
                                        @ 5:26
                                    </p>
                                    <p class="text ">
                                        Photo Id: <span class="data photo_id_box">
                                            <?php echo $photo->photo_id; ?></span>
                                    </p>
                                    <p class="text">
                                        Filename: <span class="data">
                                            <?php echo $photo->photo_filename; ?></span>
                                    </p>
                                    <p class="text">
                                        File Type: <span class="data">
                                            <?php echo $photo->photo_type; ?></span>
                                    </p>
                                    <p class="text">
                                        File Size: <span class="data">
                                            <?php echo $photo->photo_size; ?></span>
                                    </p>
                                </div>
                                <div class="info-box-footer clearfix">
                                    <div class="info-box-delete pull-left">
                                        <a href="DeletePhoto.php/?id=<?php echo $photo->photo_id; ?>" class="btn btn-danger btn-lg">Delete</a>
                                    </div>
                                    <div class="info-box-update pull-right ">
                                        <input type="submit" name="update" value="Update" class="btn btn-primary btn-lg">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
            </form>
        </div>
        <!-- /.row -->

    </div>
    <!-- /.container-fluid -->
</div>
<!-- /#page-wrapper -->

<?php include("includes/footer.php"); ?>