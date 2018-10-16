<?php include("includes/header.php"); ?>
<?php 
    if (!$session->getSignedIn()) {
        //  var_dump($session); 
         redirectTo("login.php"); 
        }

?>
<?php 
    $comments = Comment::getAll();

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
                    Comments
                    <small>Comments Admin</small>
                </h1>

                <div class="col-md-12">
                <div  class="col-md-8">
                        <?php  if (!empty($session->message)) { ?>

                        <div id="msg" class="alert alert-info">
                            <?php echo $session->message; ?>
                        </div>

                        <?php }?>
                    </div>

                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Photo</th>
                                <th>Author</th>
                                <th>Body</th>
                            </tr>
                        </thead>
                        <tbody>
                            <?php foreach ($comments as $comment) : ?>
                                <tr>
                                <td>
                                    <?php echo $comment->comment_id; ?>
                                </td>
                                <td>
                                    <!--?php echo $comment->comment_photoid; ?-->
                                    <?php $photo = Photo::getById($comment->comment_photoid);?>
                                    <img class="admin-user-thumbnail" src="<?php echo $photo->picturePath(); ?>" alt="">
                                </td>
                                <td>
                                    <?php echo $comment->comment_author; ?>
                                    <div class="actionsLink">
                                        <a href="DeleteComment.php/?id=<?php echo $comment->comment_id; ?>">Delete</a>
                                    </div>
                                </td>
                                <td>
                                <?php echo $comment->comment_body; ?>
                                </td>
                            </tr>
                            <?php endforeach; ?>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
        <!-- /.row -->

    </div>
    <!-- /.container-fluid -->
</div>
<!-- /#page-wrapper -->

<?php include("includes/footer.php"); ?>