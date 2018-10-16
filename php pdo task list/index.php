<?php 
$pageTitle = "Create Task" ;

include_once 'partials/header.php';
?>

<div class="container-fluid">
    <section class="col .col-xs-12 .col-sm-6 .col-md-8 col-lg-6 white">
        <h3 class="text-primary">Create a new task </h3><hr>
        <form id="create-task" action="" method="post" >
            <div class="form-group">
                <label for="name" class="col-md-2 control-label">Name</label>
                <div class="col-md-10">
                    <input name="name" class="form-control" id="name" type="text">
                    <span class="help-block" id="name_error"></span>
                </div>
            </div>

            <div class="form-group">
                <label for="description" class="col-md-2 control-label">Description</label>
                <div class="col-md-10">
                    <textarea class="form-control" rows="3" name="description" id="description"></textarea>
                    <span class="help-block" id="description_error"></span>
                </div>
            </div>
            <button type="submit" name="createBtn" class="btn btn-success pull-right">
                Create Task <i class="fa fa-plus"></i></button>
        </form>
    </section>
</div>

<?php include_once 'partials/footer.php';?>